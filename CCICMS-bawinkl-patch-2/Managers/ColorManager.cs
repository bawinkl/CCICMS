using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using COMMON;
using System.Windows.Forms;

namespace ColorMatchingSystem.Models
{
    public class Color
    {
        public Color() { }
        public int id;
        public string type;
        public string colorCode;
        public string name;
        public decimal inkRatio;
        public decimal calculatedGrams;
        public decimal calculatedKilograms;
        public decimal calculatedPounds;
        public string url;

        public int ID { get { return id; } set { id = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string ColorCode { get { return colorCode; } set { colorCode = value; } }
        public string Name { get { return name; } set { name = value; } }
        public decimal InkRatio { get { return inkRatio; } set { inkRatio = value; } }
        public decimal CalculatedGrams { get { return calculatedGrams; } set { calculatedGrams = value; } }
        public decimal CalculatedKilograms { get { return calculatedKilograms; } set { calculatedKilograms = value; } }
        public decimal CalculatedPounds { get { return calculatedPounds; } set { calculatedPounds = value; } }
        public string Url { get { return url; } set { url = value; } }
    }

    public class ColorManager
    {
        public ColorManager()
        {
        }

        public bool SaveCustomColor(List<Color> colorList)
        {
            if (colorList == null || colorList.FirstOrDefault() == null)
                return false;


            XDocument xmlDocument = new XDocument();
            String filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "customcolors.xml");

            try
            {
                FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
                xmlDocument = XDocument.Load(stream);
                stream.Close();
            }
            catch
            {
                xmlDocument = new XDocument(new XElement("CustomColors"));
            }

            XElement rootElement = xmlDocument.Root;

            foreach (Color c in colorList)
            {
                XElement newC = new XElement("color");
                XElement id = new XElement("id");
                XElement type = new XElement("type");
                XElement code = new XElement("colorcode");
                XElement name = new XElement("name");
                XElement ratio = new XElement("inkratio");

                id.Value = c.id.ToString();
                type.Value = c.type;
                code.Value = c.colorCode;
                name.Value = c.name;
                ratio.Value = c.inkRatio.ToString();

                newC.Add(id);
                newC.Add(type);
                newC.Add(code);
                newC.Add(name);
                newC.Add(ratio);

                rootElement.Add(newC);
            }

            try
            {
                FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);

                xmlDocument.Save(stream);
                stream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomColor(string colorCode)
        {
            XDocument xmlDocument = new XDocument();
            String filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "customcolors.xml");

            try
            {
                FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate);
                xmlDocument = XDocument.Load(stream);
                stream.Close();
            }
            catch
            {
                xmlDocument = new XDocument(new XElement("CustomColors"));
            }

            XElement rootElement = xmlDocument.Root;

            if (rootElement == null || !rootElement.HasElements)
                return false;

            List<XElement> elements = rootElement.Descendants("color").Where(c => c.Descendants("colorcode").FirstOrDefault() != null && c.Descendants("colorcode").FirstOrDefault().Value == colorCode).ToList();

            if (elements != null)
            {
                foreach (XElement elem in elements)
                    elem.Remove();
            }

            try
            {
                FileStream stream = new FileStream(filePath, FileMode.Create);
                xmlDocument.Save(stream);
                stream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public XDocument LoadData()
        {
            Assembly _assembly;
            _assembly = Assembly.GetExecutingAssembly();
            Stream stream = _assembly.GetManifestResourceStream("ColorMatchingSystemAPP.Data.Data.xml");
            XDocument colorsDocument = XDocument.Load(stream);
            XDocument customColorsDocument = null;
            stream.Close();

            String filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "customcolors.xml");

            try
            {
                FileStream customStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                customColorsDocument = XDocument.Load(customStream);
                customStream.Close();
            }
            catch (Exception ex)
            {
                try
                {
                    FileStream customStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    customColorsDocument = new XDocument(new XElement("CustomColors"));
                    customColorsDocument.Save(customStream);
                    customStream.Close();
                }
                catch
                {
                }
            }

            if (customColorsDocument != null && customColorsDocument.Root != null)
            {
                XElement root = customColorsDocument.Root;

                if (root != null && root.HasElements)
                {
                    List<XElement> elementList = root.Descendants("color").ToList();

                    if (elementList != null && elementList.FirstOrDefault() != null)
                    {
                        foreach (XElement elem in elementList)
                        {
                            XElement ratioElement = elem.Descendants("inkratio").FirstOrDefault();
                            decimal ratioValue = 0.0m;
                            ratioValue = decimal.Parse(ratioElement.Value);
                            ratioValue = ratioValue * 10;
                            ratioElement.Value = ratioValue.ToString();
                            colorsDocument.Root.Add(elem);
                        }
                    }
                }
            }

            return colorsDocument;
        }

        public int GetMaxColorID()
        {
            XDocument data = LoadData();
            string value = data.Descendants("id").Distinct().OrderByDescending(c => c.Value).FirstOrDefault().Value;
            return int.Parse(value);
        }

        public List<Color> ListColors(string type, string colorCode, decimal requestAmount, string unitOfMeasurement)
        {
            bool isRFU = (type == "Ready For Use" || type == "T-Charge");

            decimal requestAmountMultiplier = 1.0M;

            if (!String.IsNullOrEmpty(unitOfMeasurement))
            {
                switch (unitOfMeasurement)
                {
                    case "KILOGRAMS":
                        requestAmountMultiplier = 1000.0M;
                        break;
                    case "POUNDS":
                        requestAmountMultiplier = 453.59237M;
                        break;
                }
            }

            string colorURL = string.Empty;

            if (Common.ConfigVariable("DisplaySalesLinks") != null && Common.ConfigVariable("DisplaySalesLinks") == "true")
            {
                try
                {
                    colorURL = (new string[] { "CMS Pigment", "Boost" }).Contains(type) ? (Common.ConfigVariable("CMSSalesPortalURL")) : (type == "PC" ? Common.ConfigVariable("PCSalesPortalURL") : "");
                }
                catch
                {
                }
            }

            decimal requestAmountInGrams = Math.Round(requestAmount * requestAmountMultiplier, 4);
            List<Color> colorList = new List<Color>();
            XDocument data = LoadData();

            List<XElement> baseColorList = data.Descendants("color")
                                          .Where(d => d.Descendants("colorcode").FirstOrDefault() != null &&
                                                      d.Descendants("colorcode").FirstOrDefault().Value == colorCode &&
                                                      d.Descendants("type").FirstOrDefault() != null &&
                                                      d.Descendants("type").FirstOrDefault().Value == (type == "Ready For Use" || type == "T-Charge" || type.Contains("Discharge") || type.Contains("Water Base2") ? "Water Base" : type))
                                          .ToList();

            if ((baseColorList == null || baseColorList.FirstOrDefault() == null) && !type.Contains("Water Base"))
            {
                List<XElement> rcColorList = data.Descendants("color")
                                .Where(d => d.Descendants("colorcode").FirstOrDefault() != null &&
                                                      d.Descendants("colorcode").FirstOrDefault().Value == colorCode &&
                                                      d.Descendants("type").FirstOrDefault() != null &&
                                                      d.Descendants("type").FirstOrDefault().Value == "Water Base")
                                                      .ToList();

                if (rcColorList != null)
                {
                    foreach (XElement rcColor in rcColorList)
                    {
                        string rcInkColorRatio = rcColor.Descendants("inkratio").FirstOrDefault().Value;
                        decimal rcInkRatio = decimal.Parse(rcInkColorRatio);

                        string rcColorName = rcColor.Descendants("name").FirstOrDefault().Value;

                        List<XElement> subColors = data.Descendants("color")
                                                       .Where(d => d.Descendants("colorcode").FirstOrDefault() != null &&
                                                                    d.Descendants("colorcode").FirstOrDefault().Value == rcColorName &&
                                                                    d.Descendants("type").FirstOrDefault() != null &&
                                                                    d.Descendants("type").FirstOrDefault().Value == type)
                                                        .ToList();

                        if (subColors != null)
                        {
                            foreach (XElement subColor in subColors)
                            {
                                string thisInkRatioString = subColor.Descendants("inkratio").FirstOrDefault().Value;
                                decimal thisInkRatio = decimal.Parse(thisInkRatioString);
                                decimal modifiedInkRatio = Math.Round((thisInkRatio / 100) * rcInkRatio, 6);
                                subColor.Descendants("inkratio").FirstOrDefault().Value = modifiedInkRatio.ToString();
                            }

                            baseColorList = baseColorList.Concat(subColors).ToList();
                        }
                    }
                }
            }

            decimal mixingBaseRatio = 0.0m;
            Dictionary<string, string> colorTypes = ListColorTypes();

            if ((baseColorList == null || baseColorList.FirstOrDefault() == null) && (colorCode.Contains("Water Base") || type.Contains("DISCHARGE")))
            {
                Color newColor = new Color();
                newColor.id = 0;
                newColor.type = colorTypes[type];
                newColor.name = colorCode;
                newColor.inkRatio = 10.0m;
                newColor.url = String.IsNullOrEmpty(colorURL) ? colorURL : string.Empty;
                newColor.calculatedGrams = Math.Round((newColor.inkRatio / 100) * requestAmountInGrams, 2);
                newColor.calculatedKilograms = Math.Round(((newColor.inkRatio / 100) * requestAmountInGrams) / 1000.0M, 2);
                newColor.calculatedPounds = Math.Round(((newColor.inkRatio / 100) * requestAmountInGrams) / 453.59237M, 2);
                colorList.Add(newColor);

                Color newBase = new Color();
                newBase.id = 0;
                newBase.type = colorTypes[type];
                newBase.name = "Mixing Base";
                newBase.inkRatio = 90.0m;
                newBase.url = String.IsNullOrEmpty(colorURL) ? colorURL : string.Empty;
                newBase.calculatedGrams = Math.Round((newBase.inkRatio / 100) * requestAmountInGrams, 2);
                newBase.calculatedKilograms = Math.Round(((newBase.inkRatio / 100) * requestAmountInGrams) / 1000.0M, 2);
                newBase.calculatedPounds = Math.Round(((newBase.inkRatio / 100) * requestAmountInGrams) / 453.59237M, 2);
                colorList.Add(newBase);
            }
            else
            {
                foreach (XElement color in baseColorList)
                {
                    try
                    {
                        string thisColorType = colorTypes[color.Descendants("type").FirstOrDefault().Value];
                        string thisColorCode = color.Descendants("colorcode").FirstOrDefault().Value;
                        string thisIdString = color.Descendants("id").FirstOrDefault().Value;
                        string thisColorName = color.Descendants("name").FirstOrDefault().Value;
                        int thisId = int.Parse(thisIdString);
                        string thisInkRatioString = color.Descendants("inkratio").FirstOrDefault().Value;
                        decimal thisInkRatio = decimal.Parse(thisInkRatioString);
                        string thisURL = color.Descendants("url") != null && color.Descendants("url").FirstOrDefault() != null ? color.Descendants("url").FirstOrDefault().Value : string.Empty;


                        if (type != "Ready For Use" && type != "T-Charge")
                        {
                            if (type.Contains("CMS Pigment") && type.Contains('5'))
                            {
                                mixingBaseRatio += (thisInkRatio * .85m);
                                thisInkRatio = thisInkRatio * .15m;
                            }
                            else
                            {
                                mixingBaseRatio += (thisInkRatio * .9m);
                                thisInkRatio = thisInkRatio * .1m;
                            }
                        }
                        else
                        {
                            if (thisColorName.Contains("021"))
                                thisColorName = thisColorName.Replace("021", "");

                            thisColorType = colorTypes[type];
                        }

                        if (colorList != null && colorList.FirstOrDefault() != null)
                        {
                            Color existingColor = colorList.FirstOrDefault(cl => cl.name == thisColorName);
                            if (existingColor != null)
                            {
                                thisInkRatio = existingColor.inkRatio + thisInkRatio;
                                colorList.Remove(existingColor);
                            }
                        }

                        Color newColor = new Color();
                        newColor.id = thisId;
                        newColor.type = colorTypes[type];
                        newColor.colorCode = thisColorCode;
                        newColor.name = thisColorName;
                        newColor.inkRatio = thisInkRatio;
                        newColor.url = String.IsNullOrEmpty(thisURL) ? colorURL : thisURL;
                        newColor.calculatedGrams = Math.Round((thisInkRatio / 100) * requestAmountInGrams, 2);
                        newColor.calculatedKilograms = Math.Round(((thisInkRatio / 100) * requestAmountInGrams) / 1000.0M, 2);
                        newColor.calculatedPounds = Math.Round(((thisInkRatio / 100) * requestAmountInGrams) / 453.59237M, 2);
                        colorList.Add(newColor);
                    }
                    catch
                    {
                    }
                }

                if (type != "Custom" && (type != "Ready For Use" && type != "T-Charge"))
                {
                    Color baseColor = new Color();
                    baseColor.id = -1;
                    baseColor.type = colorTypes[type];
                    baseColor.name = "Mixing Base";
                    baseColor.inkRatio = mixingBaseRatio;
                    baseColor.url = colorURL;
                    baseColor.calculatedGrams = Math.Round((mixingBaseRatio / 100) * requestAmountInGrams, 2);
                    baseColor.calculatedKilograms = Math.Round(((mixingBaseRatio / 100) * requestAmountInGrams) / 1000.0M, 2);
                    baseColor.calculatedPounds = Math.Round(((mixingBaseRatio / 100) * requestAmountInGrams) / 453.59237M, 2);
                    colorList.Add(baseColor);
                }
            }

            return colorList;
        }

        public List<String> ListColorCodes()
        {
            return ListColorCodes(String.Empty);
        }

        public List<String> ListColorCodes(string colorTypes)
        {
            if (colorTypes == "Water Base2")
                colorTypes = "Water Base";

            List<String> colorCodes = new List<String>();
            XDocument data = LoadData();
            List<XElement> codeList = data.Descendants("colorcode").Distinct().Where(s => String.IsNullOrEmpty(colorTypes) || s.Parent.Element("type").Value == (colorTypes == "Ready For Use" || colorTypes == "T-Charge" || colorTypes.Contains("Discharge") || colorTypes.Contains("Water Base2") ? "Water Base" : colorTypes)).ToList();

            if (colorTypes == "Ready For Use" || colorTypes == "T-Charge")
                codeList = codeList.Where(c => !c.Value.Contains("RFU")).ToList();

            foreach (XElement colorCode in codeList)
            {
                if (colorTypes == "Ready For Use" || colorTypes == "T-Charge" && colorCode.Value.Contains("RFU"))
                    continue;

                if (colorTypes == "Ready For Use")
                {
                    if (colorCode.Value == "Orange 021")
                        colorCode.Value = "Orange";
                }
            }

            return codeList.OrderByDescending(c => c.Value.Contains("RFU") ? 1 : 0).ThenBy(c => c.Attribute("sortorder") != null ? int.Parse(c.Attribute("sortorder").Value) : 9999999).ThenBy(c => c.Value, new NaturalComparer()).Select(c => c.Value).Distinct().ToList();
        }

        public Dictionary<String, String> ListColorTypes()
        {
            Dictionary<String, String> colorTypes = new Dictionary<String, String>();
            XDocument data = LoadData();

            string allowedColorTypes = string.Empty;
            List<string> allowedColorTypeList = new List<string>();

            try
            {
                allowedColorTypes = Common.ConfigVariable("DisplayTypes");

                if (allowedColorTypes.Contains(","))
                {
                    string[] tempList = allowedColorTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tempList.Count() > 0)
                    {
                        foreach (string type in tempList)
                            allowedColorTypeList.Add(type);
                    }
                }
                else
                    allowedColorTypeList.Add(allowedColorTypes);
            }
            catch
            {
            }

            foreach (XElement colorType in data.Descendants("type"))
            {
                if ((colorTypes == null || !colorTypes.Keys.Contains(colorType.Value)) && allowedColorTypeList != null && allowedColorTypeList.Contains(colorType.Value))
                    colorTypes.Add(colorType.Value, colorType.Value);
            }

            if (!colorTypes.Keys.Contains("CMS Pigment"))
                colorTypes.Add("Water Base", "CMS Pigment");

            if (!colorTypes.Keys.Contains("CMS Pigment (+5%)"))
                colorTypes.Add("Discharge", "CMS Pigment (+5%)");

            if (!colorTypes.Keys.Contains("Boost"))
                colorTypes.Add("Water Base2", "Boost");

            if (!colorTypes.Keys.Contains("T-Charge"))
                colorTypes.Add("Ready For Use", "T-Charge");

            return colorTypes;
        }

        public Dictionary<string, string> ListUnitsOfMeasurement()
        {
            Dictionary<string, string> uomList = new Dictionary<string, string>();
            uomList.Add("GRAMS", "Grams (g.)");
            uomList.Add("KILOGRAMS", "Kilograms (kg.)");
            uomList.Add("POUNDS", "Pounds (lbs.)");
            return uomList;
        }
    }
}
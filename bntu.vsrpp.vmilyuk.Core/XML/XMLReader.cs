using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace bntu.vsrpp.vmilyuk.Core.XML
{
    public class XMLReader
    {
        /// <summary>
        /// Read xml file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public XDocument ReadXML(string path)
        {
            XDocument xml = XDocument.Load(path);
            return xml;
        }

        /// <summary>
        /// Returns count child nodes
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        public int GetNodesCount(List<XElement> Node)
        {
            var count = Node.Count();
            return count;
        }

        /// <summary>
        /// Method that displays the available options for operations
        /// </summary>
        /// <returns>Available options</returns>
        public List<string> GetAvailiableStrings(List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            var value = ChildNode.Distinct().ToList();
            foreach (string item in value)
            {
                if (Node.All(x => x.Elements().Any(x => x.Name.ToString().Equals(item))))
                    if (!AvaliableStringValues.Contains(item))
                        AvaliableStringValues.Add(item);
            }

            return AvaliableStringValues;
        }

        /// <summary>
        /// Getting a list of numbers for number operations
        /// </summary>
        /// <param name="element">Combobox selected item</param>
        /// <returns></returns>
        private List<int> GetIntValues(string element, List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            GetAvailiableStrings(ChildNode, Node, AvaliableStringValues);
            List<int> values = new List<int>();

            foreach (var item in Node)
            {
                foreach (var i in item.Elements().Where(x => x.Name.ToString().Equals(element)))
                    if (Int32.TryParse(i.Value, out int temp))
                        values.Add(temp);
            }

            return values;
        }

        /// <summary>
        /// Getting a list of strings for string operations
        /// </summary>
        /// <param name="element">Combobox selected item</param>
        /// <returns></returns>
        private List<string> GetStringValues(string element, List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            GetAvailiableStrings(ChildNode, Node, AvaliableStringValues);
            List<string> values = new List<string>();

            foreach (var item in Node)
            {
                foreach (var i in item.Elements().Where(x => x.Name.ToString().Equals(element)))
                    if (!Int32.TryParse(i.Value, out int temp))
                        values.Add(i.Value.ToString());
            }

            return values;
        }

        #region ShitMethodsToDisplayResult

        /// <summary>
        /// Returns max length of the string
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ChildNode"></param>
        /// <param name="Node"></param>
        /// <param name="AvaliableStringValues"></param>
        /// <returns></returns>
        public int GetMaxLength(string element, List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            var str = GetStringValues(element, ChildNode, Node, AvaliableStringValues).OrderByDescending(s => s.Length).First();
            return str.Length;
        }

        /// <summary>
        /// Returns min length of the string
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ChildNode"></param>
        /// <param name="Node"></param>
        /// <param name="AvaliableStringValues"></param>
        /// <returns></returns>
        public int GetMinLength(string element, List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            var str = GetStringValues(element, ChildNode, Node, AvaliableStringValues).OrderBy(s => s.Length).First();
            return str.Length;
        }

        /// <summary>
        /// Returns average length of the string
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ChildNode"></param>
        /// <param name="Node"></param>
        /// <param name="AvaliableStringValues"></param>
        /// <returns></returns>
        public double GetAverageLength(string element, List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            var average = GetStringValues(element, ChildNode, Node, AvaliableStringValues).Average(x => x.Length);
            return average;
        }

        /// <summary>
        /// Returns max numeric value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ChildNode"></param>
        /// <param name="Node"></param>
        /// <param name="AvaliableStringValues"></param>
        /// <returns></returns>
        public int GetMax(string element, List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            var max = GetIntValues(element, ChildNode, Node, AvaliableStringValues).Max();
            return max;
        }

        /// <summary>
        /// Returns min numeric value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ChildNode"></param>
        /// <param name="Node"></param>
        /// <param name="AvaliableStringValues"></param>
        /// <returns></returns>
        public int GetMin(string element, List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            var min = GetIntValues(element, ChildNode, Node, AvaliableStringValues).Min();
            return min;
        }

        /// <summary>
        /// Returns average numeric value
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ChildNode"></param>
        /// <param name="Node"></param>
        /// <param name="AvaliableStringValues"></param>
        /// <returns></returns>
        public double GetAverage(string element, List<string> ChildNode, List<XElement> Node, List<string> AvaliableStringValues)
        {
            var average = GetIntValues(element, ChildNode, Node, AvaliableStringValues).Average();
            return average;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRNUIElements.Models.Structure
{
    class KeyValueModel
    {
        public string paramName { get; set; }
        public string paramValue { get; set;}
        public string TagName { get; set; }

        public List<string> TagNames = new List<string>();


        public int BeginTagSubstringPlacement(string TextToParse, string TagName)
        {
          

            if (TextToParse.IndexOf(TagName) > -1)
                return TextToParse.IndexOf(TagName)+TagName.Length;
            else 
            return int.Parse("0");
        }
        public string MakeClosingTag(string openingTagName)
        {

           return openingTagName.Insert(1, "/");

        }
        

        public virtual string GetParamValue(string TextToParse, string ParamName, string TagName)
        {
            string value = TextToParse;
            int a = 0;
            if (TagName != null)
            {
               
                if (TextToParse.Contains(TagName))
                {
                    value = value.Remove(value.IndexOf(TagName) + TagName.Length - 1);
                    string Tagname = value.Remove(value.IndexOf(MakeClosingTag(TagName)) + 1);
                }
            }



            if (TextToParse.Contains(ParamName)) {
                value = TextToParse.Remove(0,TextToParse.IndexOf(ParamName)+ParamName.Length+2);
                //    (value.IndexOf('\"')-value.IndexOf(ParamName)));
                //value = value.Remove(value.IndexOf("\""));
                return value.Remove(value.IndexOf("\"")); } 
            
           
            return string.Empty;

            
           
            
        }
        public virtual List<string> GetTagTextBlockText(string TextToParse, string ParamName, string TagName)
        {
            int a = 0;
 List<string> list = new List<string>();
            string value = TextToParse;
            if (TextToParse.Contains(TagName))
            {
               
                list.Add(value.Substring(value.IndexOf(TagName) + TagName.Length , value.Length - value.IndexOf(MakeClosingTag(TagName))));
                char[] ca = "/r/n".ToCharArray();
                if (value.Contains(ParamName))
                    list = value.Split(ca, StringSplitOptions.RemoveEmptyEntries).ToList();

                return list;
            }
            return list;
        }
        public virtual List<string> GetParamValue(string TextToParse, List<string> ParamNames, string TagName)
        {
            List<string> values = new List<string>();
            int a = 0;
          
            string value = TextToParse;
            if (TextToParse.Contains(TagName))
            {
                a = int.Parse(value.Remove(value.IndexOf(TagName) + TagName.Length));
                string Tagname = value.Remove(value.IndexOf("</"));
            }
            value = TextToParse.Substring(BeginTagSubstringPlacement(TextToParse, TagName), TextToParse.IndexOf(MakeClosingTag(TagName)));


            foreach (string s in ParamNames)
            if (TextToParse.Contains(s))
            {
                    string thisvalue = value;
                thisvalue = thisvalue.Remove(thisvalue.IndexOf(s) + s.Length);
                    thisvalue = thisvalue.Remove(thisvalue.IndexOf("\""));

                 values.Add(thisvalue.Remove(thisvalue.IndexOf("\"")));
            }

            return values;
        }

        public  double GetParamValued(string TextToParse, string ParamName, string TagName)
        {
            int a = 0;
          
            string value = TextToParse;
            if (TextToParse.Contains(TagName))
            {
                a = int.Parse(value.Remove(value.IndexOf(TagName) + TagName.Length));
                string Tagname = value.Remove(value.IndexOf("</"));
            }



            if (TextToParse.Contains(ParamName))
            {
                value = value.Remove(value.IndexOf(ParamName) + ParamName.Length);
                value.Remove(value.IndexOf("\""));
                return double.Parse(value.Remove(value.IndexOf("\"")));
            }
            return 0;
        }
    }
}

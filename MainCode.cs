using System;
using System.Collections.Generic;
using System.IO;
using NPOI.XWPF.UserModel;

namespace TIAS.Tools.Trello
{
    public static class TrelloParser
    {
        public static void MakeDocx(string docx_filename, TrelloData data, string caption)
        {
            using (var fs = 
                new System.IO.FileStream(docx_filename, 
                                         System.IO.FileMode.Create, 
                                         System.IO.FileAccess.Write))
            {
                XWPFDocument doc = new XWPFDocument();

                var p0 = doc.CreateParagraph();
                p0.Alignment = ParagraphAlignment.CENTER;
                XWPFRun r0 = p0.CreateRun();
                r0.FontFamily = "Arial";
                r0.FontSize = 14;
                r0.IsBold = true;
                r0.SetText(caption);

                for (int i = data.lists.Count-1; i >= 0; i--)
                {
                    PrintParagraph(doc, 14, true, data.lists[i].name);

                    for (int j = 0; j < data.cards.Count; j++)
                    {
                        if (data.lists[i].id == data.cards[j].idList)
                        {
                            PrintParagraph(doc, 12, false, data.cards[j].name);
                            foreach(var line in ReadLines(data.cards[j].desc)) 
                            {
                                PrintParagraph(doc, 12, false, line);
                            }
                            
                            //PrintParagraph(doc, 12, false, "");
                        }
                    }

                    PrintParagraph(doc, 14, false, "");
                }

                doc.Write(fs);
            }
        }

        private static void PrintParagraph(XWPFDocument doc,
                                           int fontSize, 
                                           bool isBold,
                                           string text)
        {
            var p = doc.CreateParagraph();
            p.Alignment = ParagraphAlignment.LEFT;
            p.IndentationFirstLine = 500;
            XWPFRun r = p.CreateRun();
            r.FontFamily = "Arial";
            r.FontSize = fontSize;
            r.IsBold = isBold;
            r.SetText(text);
        }

        internal static IEnumerable<string> ReadLines(this string s)
        {
            string line;
            using (var sr = new StringReader(s))
                while ((line = sr.ReadLine()) != null)
                    yield return line;
        }
    }
}
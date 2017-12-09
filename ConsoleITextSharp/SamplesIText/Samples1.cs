using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace ConsoleITextSharp.SamplesIText
{
    public class Samples1
    {
        //ctor
        public Samples1()
        {
            //Environment.CurrentDirectory = C:\Users\jlopes\Desktop\ConsoleITextSharp\ConsoleITextSharp\bin\Debug
            //usando o .Parent ele voltou duas pastas
            //applicationRoot = C:\Users\jlopes\Desktop\ConsoleITextSharp\ConsoleITextSharp
            //eliminando as pastas "\bin\Debug"
            string applicationRoot = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

            try
            {
                using (FileStream fs = new FileStream(applicationRoot + "/PDF/FileExample1.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //AQUI NOS SETAMOS AS CONFIGURAÇÕES DO DOCUMENTO QUE VAMOS GERAR
                    using(Document doc = new Document(PageSize.A4))
                    {
                        //AQUI NOS PASSAMOS AS INFOMRAÇÕES DAS VARIAVEIS RESPONSAVEIS PELO
                        //DOCUMETO doc E A VARIAVEL RESPONSAVEL POR GRAVAR ESTE ARQUIVO NA MAQUINA
                        //QUE É A VARIAVEL fs
                        using (PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs))
                        {
                            //ABRIMOS O DOCUMENTO
                            doc.Open();

                            //CRIAMOS REPONSAVEIS PELAS FONTS DO NOSSO PDF
                            //UTILIZANDO FONT FABRICA
                            var fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f, BaseColor.GREEN);
                            var fontArialBold = FontFactory.GetFont("Arial", 20f, Font.BOLD, BaseColor.RED);

                            doc.Add(new Paragraph("Conhencendo o ITextShap"));
                            doc.Add(new Paragraph("Paragrafo 1", new Font(Font.FontFamily.HELVETICA, 40, 0, BaseColor.BLUE)));
                            doc.Add(new Paragraph("Paragrafo 2", fontBold));
                            doc.Add(new Paragraph("Paragrafo 3", fontArialBold));

                            doc.Close();
                        }

                    }
                }

            }
            catch (DocumentException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

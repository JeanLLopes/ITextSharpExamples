using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace ConsoleITextSharp.SamplesIText
{
    public class Samples3
    {
        //ctor
        public Samples3()
        {
            //Environment.CurrentDirectory = C:\Users\jlopes\Desktop\ConsoleITextSharp\ConsoleITextSharp\bin\Debug
            //usando o .Parent ele voltou duas pastas
            //applicationRoot = C:\Users\jlopes\Desktop\ConsoleITextSharp\ConsoleITextSharp
            //eliminando as pastas "\bin\Debug"
            string applicationRoot = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

            try
            {
                using (FileStream fs = new FileStream(applicationRoot + "/PDF/FileExample3.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
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

                            var image1 = Image.GetInstance(applicationRoot + "/Images/simpsom.png");

                            //aqui nos definimos quando de escala nos vamos usar
                            //original ela vai ter 100% de escala
                            //voce pode aumentar ou diminuir a escala para 
                            //aumentar ou diminuir a imagem
                            image1.ScalePercent(25f);
                            doc.Add(image1);

                            var image2 = Image.GetInstance(applicationRoot + "/Images/nozes.jpg");
                            image2.ScalePercent(5f);

                            doc.Add(image2);


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

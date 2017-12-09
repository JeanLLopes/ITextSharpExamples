using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace ConsoleITextSharp.SamplesIText
{
    public class Samples2
    {
        //ctor
        public Samples2()
        {
            //Environment.CurrentDirectory = C:\Users\jlopes\Desktop\ConsoleITextSharp\ConsoleITextSharp\bin\Debug
            //usando o .Parent ele voltou duas pastas
            //applicationRoot = C:\Users\jlopes\Desktop\ConsoleITextSharp\ConsoleITextSharp
            //eliminando as pastas "\bin\Debug"
            string applicationRoot = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

            try
            {
                using (FileStream fs = new FileStream(applicationRoot + "/PDF/FileExample2.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //AQUI NOS SETAMOS AS CONFIGURAÇÕES DO DOCUMENTO QUE VAMOS GERAR
                    //TAMBEM DEFINIMOS AS MARGENS DO NOSSO DOCUMENTO
                    using(Document doc = new Document(PageSize.A4, 5f,5f,10f,10f))
                    {
                        //AQUI NOS PASSAMOS AS INFOMRAÇÕES DAS VARIAVEIS RESPONSAVEIS PELO
                        //DOCUMETO doc E A VARIAVEL RESPONSAVEL POR GRAVAR ESTE ARQUIVO NA MAQUINA
                        //QUE É A VARIAVEL fs
                        using (PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs))
                        {
                            //ABRIMOS O DOCUMENTO
                            doc.Open();

                            //CRIAMOS AS FONTS
                            var font1 = FontFactory.GetFont("Calibri", 12f, Font.BOLD);
                            var font2 = FontFactory.GetFont("Calibri", 12f, Font.BOLD,BaseColor.WHITE);

                            //definimos as imagens do projeto
                            var image1 = Image.GetInstance(applicationRoot + "/Images/simpsom.png");
                            image1.ScalePercent(20f);

                            //PASSAMOS UM PARAMETRO COM A QUANTIDADE DE 
                            //COLUNAS QUE VAMOS TER
                            //DEFENIMOS APENAS A TABELA
                            var pdfTable = new PdfPTable(7);


                            var cellImage = new PdfPCell(image1);
                            cellImage.Border = 0;
                            cellImage.Colspan = 2;
                            pdfTable.AddCell(cellImage);


                            cellImage = new PdfPCell(new Phrase(""));
                            cellImage.Border = 0;
                            pdfTable.AddCell(cellImage);

                            cellImage = new PdfPCell(new Phrase("NOME DA EMPRESA \nCNPJ: 000.000.000/10000 \nENDEREÇO: RUA TESTE n° 666 BAIRRO: TESTE"));
                            cellImage.Colspan = 5;
                            cellImage.Border = 0;
                            pdfTable.AddCell(cellImage);

                            cellImage = new PdfPCell(new Phrase("\n\n"));
                            cellImage.Border = 10;
                            cellImage.BorderColor = BaseColor.WHITE;
                            cellImage.Colspan = 7;
                            pdfTable.AddCell(cellImage);


                            //VAMOS DEFINIR AS CELULAR DA TABELA
                            var cell = new PdfPCell(new Phrase("Data"));
                            //AQUI NOS PODEMOS ALINHAR NOSSO TEXTO DENTRO DA CELULA
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Avulso"));
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Mensalista"));
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("Convênio"));
                            cell.Colspan = 2;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("DATA", font1));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.BackgroundColor = new BaseColor(173, 212, 167);
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("QTDE", font1));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.BackgroundColor = new BaseColor(173, 212, 167);
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("VALOR", font1));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.BackgroundColor = new BaseColor(173, 212, 167);
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("QTDE", font1));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.BackgroundColor = new BaseColor(173, 212, 167);
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("VALOR", font1));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.BackgroundColor = new BaseColor(173, 212, 167);
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("QTDE", font2));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.BackgroundColor = new BaseColor(173, 212, 167);
                            pdfTable.AddCell(cell);

                            cell = new PdfPCell(new Phrase("VALOR", font1));
                            cell.HorizontalAlignment = Element.ALIGN_LEFT;
                            cell.BackgroundColor = new BaseColor(173, 212, 167);
                            pdfTable.AddCell(cell);


                            //ADICIONO A MINHA TABELA AO MEU DOCUMENTODD
                            doc.Add(pdfTable);

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

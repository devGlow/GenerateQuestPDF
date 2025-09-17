using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace GeneratePDF
{
    public class SimpleFactureTemplate : IDocument
    {
        private readonly string _refFacture;

        public SimpleFactureTemplate(string refFacture)
        {
            _refFacture = refFacture;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(12));
                page.PageColor(Colors.White);

                page.Header().Text($"Facture N° {_refFacture}").FontSize(20).Bold();

                page.Content().Column(col =>
                {
                    // Company Info
                    col.Item().Text("Entreprise ABC").Bold();
                    col.Item().Text("123 Rue de Paris, 75000 Paris");

                    col.Item().PaddingVertical(10);

                    // Client Info
                    col.Item().Text("Client : Jean Dupont").Bold();
                    col.Item().Text("45 Avenue des Champs, 75008 Paris");

                    col.Item().PaddingVertical(10);

                    // Invoice Info
                    col.Item().Text($"Facture N°: {_refFacture}").Bold();
                    col.Item().Text("Date: 28/05/2025");

                    col.Item().PaddingVertical(20);

                    // Table Header
                    col.Item().Row(row =>
                    {
                        row.RelativeItem(4).Text("Description").Bold();
                        row.RelativeItem(2).AlignRight().Text("Quantité").Bold();
                        row.RelativeItem(3).AlignRight().Text("Prix Unitaire").Bold();
                        row.RelativeItem(3).AlignRight().Text("Total").Bold();
                    });

                    col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                    // Table Rows (Static Items)
                    col.Item().Row(row =>
                    {
                        row.RelativeItem(4).Text("Produit A");
                        row.RelativeItem(2).AlignRight().Text("2");
                        row.RelativeItem(3).AlignRight().Text("50 €");
                        row.RelativeItem(3).AlignRight().Text("100 €");
                    });

                    col.Item().Row(row =>
                    {
                        row.RelativeItem(4).Text("Service B");
                        row.RelativeItem(2).AlignRight().Text("1");
                        row.RelativeItem(3).AlignRight().Text("150 MAD");
                        row.RelativeItem(3).AlignRight().Text("150 MAD");
                    });

                    col.Item().PaddingVertical(10);
                    col.Item().LineHorizontal(1).LineColor(Colors.Black);

                    // Total
                    col.Item().AlignRight().Text("Total: 250 MAD").FontSize(14).Bold();
                });

                page.Footer().AlignCenter().Text("Merci pour votre achat !").Italic().FontSize(10);
            });
        }
    }
}

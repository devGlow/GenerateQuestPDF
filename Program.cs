// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using GeneratePDF;
using HarfBuzzSharp;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

QuestPDF.Settings.License = LicenseType.Community;

List<string> listFactures = new List<string>
{
    "FAC_19", "FAC_31", "FAC_23", "FAC_1", "FAC_17",
    "FAC_38", "FAC_30", "FAC_10", "FAC_36", "FAC_27",
    "FAC_2", "FAC_47", "FAC_20", "FAC_43", "FAC_48",
    "FAC_4", "FAC_25", "FAC_24", "FAC_37", "FAC_49",
    "FAC_6", "FAC_26", "FAC_44", "FAC_8", "FAC_34",
    "FAC_50", "FAC_12", "FAC_11", "FAC_32", "FAC_13",
    "FAC_21", "FAC_40", "FAC_16", "FAC_35", "FAC_33",
    "FAC_45"
};

string folderPath = @"C:\MyApp\SampleFactures";

try
{
    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
    }

    foreach (var f in listFactures)
    {
        var document = new SimpleFactureTemplate(f);
        var fileName = $"facture_{f}.pdf";
        string fullPath = Path.Combine(folderPath, fileName);

        document.GeneratePdf(fullPath);
    }

    Console.WriteLine("PDF files generated successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

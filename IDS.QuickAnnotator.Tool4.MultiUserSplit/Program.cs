namespace IDS.QuickAnnotator.Tool4.MultiUserSplit
{
    internal class Program
    {
        static int Main(string[] args)
        {
            if (args is null || args.Length < 3)
            {
                Console.Error.WriteLine("Usage: <inputDir> <splitCount> <outputDir>");
                return 1;
            }

            var inputDir = args[0];
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory does not exist: {inputDir}");
                return 2;
            }

            if (!int.TryParse(args[1], out var split) || split < 2)
            {
                Console.Error.WriteLine("splitCount must be an integer >= 2");
                return 3;
            }

            var outputDir = args[2];

            try
            {
                // 1. Erzeuge die split-Ordner im output-Verzeichnis
                for (var i = 1; i <= split; i++)
                {
                    var dir = Path.Combine(outputDir, i.ToString());
                    Directory.CreateDirectory(dir);
                }

                // 2. Nimm alle Dateien aus input (nur top-level)
                var jsonFiles = Directory.GetFiles(inputDir, "*", SearchOption.TopDirectoryOnly);
                if (jsonFiles.Length == 0)
                {
                    Console.WriteLine("Keine Dateien im Eingangsordner gefunden.");
                    return 0;
                }

                // 3. Verteile die Dateien, jede Datei in zwei aufeinanderfolgenden Ordnern
                var count = 0;
                for (var i = 0; i < jsonFiles.Length; i++)
                {
                    var src = jsonFiles[i];
                    var fileName = Path.GetFileName(src);

                    var firstIndex = (i % split) + 1;
                    var secondIndex = ((i + 1) % split) + 1;

                    var dest1 = Path.Combine(outputDir, firstIndex.ToString(), fileName);
                    var dest2 = Path.Combine(outputDir, secondIndex.ToString(), fileName);

                    File.Copy(src, dest1, overwrite: true);
                    File.Copy(src, dest2, overwrite: true);

                    count++;
                }

                Console.WriteLine($"Erledigt: {count} Dateien verteilt auf {split} Ordner (je Datei 2 Kopien).");
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Fehler: {ex.Message}");
                return 4;
            }
        }
    }
}

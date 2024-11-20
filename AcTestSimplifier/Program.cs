using System.Xml;

internal class Program
{
   private static void Main(string[] args)
   {
      if (args.Length != 2)
      {
         Console.WriteLine("Usage: FileCompare <NewPath>  <OldPath>");
      }


      var newPath = args[0];
      if (!Directory.Exists(newPath))
      {
         Console.WriteLine("NEW directory does not exist in " + newPath);
      }
      var oldPath = args[1];

      if (!Directory.Exists(oldPath))
      {
         Console.WriteLine("OLD directory does not exist in " + oldPath);
      }

      var newFiles = Directory.GetFiles(newPath);
      var oldFiles = Directory.GetFiles(oldPath);

      if (newFiles.Length != oldFiles.Length)
      {
         Console.WriteLine("Number of files in NEW and OLD directories do not match");
         return;
      }
      bool areFilesIdentical = true;

      for (int i = 0; i < newFiles.Length; i++)
      {
         var newContent = File.ReadAllText(newFiles[i]);
         var oldContent = File.ReadAllText(oldFiles[i]);

         if (newContent.Length != oldContent.Length)
         {
            areFilesIdentical = false;
            Console.WriteLine("File " + newFiles[i] + " has different length");
            continue;
         }

         if (newContent != oldContent)
         {
            areFilesIdentical = false;
            Console.WriteLine("File " + newFiles[i] + " has different content");
            continue;
         }
      }

      if(areFilesIdentical)
         Console.WriteLine("Files are identical");
      else
         Console.WriteLine("Files are different");
   }
}
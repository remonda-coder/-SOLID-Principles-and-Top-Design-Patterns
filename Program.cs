using System.Text;
using System;

public class HelloWorld
{
   public static void Main(string[] args)
   {
       string sharedFile = "logs.txt";
       File.WriteAllText(sharedFile, "--- LOG START ---\n");

       Console.WriteLine("=== TESTING EAGER LOGGER ===");
        
        
       EagerFileLogger eager = EagerFileLogger.Instance;
        
       
       eager.Log("System booting up.");
        
  
       Console.WriteLine(eager.ReadLogs());


       Console.WriteLine("\n=== TESTING LAZY LOGGER ===");
        
        
       LazyFileLogger lazy = LazyFileLogger.Instance;
        
      
       lazy.Log("User logged in.");
        
      
       Console.WriteLine(lazy.ReadLogs());
        
        
       Console.WriteLine("\n=== TESTING SINGLETON BEHAVIOR ===");
       
       var eager2 = EagerFileLogger.Instance;
       bool isSame = ReferenceEquals(eager, eager2);
       Console.WriteLine($"Is eager instance 1 same as instance 2? {isSame}"); // True
   }
   public class EagerFileLogger{
       private static readonly EagerFileLogger _instance=new();
       private string _filePath = "logs.txt";

       private EagerFileLogger(){}
       public static EagerFileLogger Instance{
           get{
               return _instance;
           }
       }

       public void Log(string message){
           string timestamp = DateTime.Now.ToString("HH:mm:ss");
       string fullMessage = $"[{timestamp}] EAGER:  {message}\n";
        
       File.AppendAllText(_filePath, fullMessage);
       }

       public string ReadLogs(){
           if(File.Exists(_filePath))
               return File.ReadAllText(_filePath);
           return "File not found.";
       }
        
   }
   public class LazyFileLogger{
       private static LazyFileLogger _instance;
       private string _filePath = "logs.txt";
       private LazyFileLogger(){}
       public static LazyFileLogger Instance{
           get{
               if(_instance==null)
                   _instance=new();
               return _instance;
           }
       }
        
       public void Log(string message){
           string timestamp = DateTime.Now.ToString("HH:mm:ss");
       string fullMessage = $"[{timestamp}] LAZY:  {message}\n";
        
       File.AppendAllText(_filePath, fullMessage);
       }

       public string ReadLogs(){
           if(File.Exists(_filePath))
               return File.ReadAllText(_filePath);
           return "File not found.";
       }
   }
}



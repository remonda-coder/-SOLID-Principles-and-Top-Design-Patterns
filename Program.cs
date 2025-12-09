using System.Text;
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Structural Adapter Test ---");

        LegacyRectangle legacyItem = new LegacyRectangle(10, 10, 20, 10);

        IRectangle adapter = new LegacyRectangleAdapter(legacyItem);

        Console.WriteLine($"Legacy X: {legacyItem.x} | Legacy W: {legacyItem.w}");
        
        Console.WriteLine("--- ADAPTED VALUES ---");
        Console.WriteLine($"Adapted x1: {adapter.x1}"); 
        Console.WriteLine($"Adapted y1: {adapter.y1}"); 
        Console.WriteLine($"Adapted x2: {adapter.x2}"); 
        Console.WriteLine($"Adapted y2: {adapter.y2}"); 
    }
    //interface 
    public interface IRectangle
    {
        int x1 { get; set; }
        int y1 { get; set; }
        int x2 { get; set; }
        int y2 { get; set; }
    }
    //class need to adapt 
    public class LegacyRectangle
    {
        public int x {get;set;}
        public int y {get;set;}
        public int w {get;set;}
        public int h {get;set;}
        public LegacyRectangle(int x,int y, int w, int h)
        {
            this.x=x;
            this.y=y;
            this.w=w;
            this.h=h;
        }
    }
    public class NewRectangle:IRectangle
    {
        public int x1 {get;set;}
        public int y1 {get;set;}
        public int x2 {get;set;}
        public int y2 {get;set;}
        public NewRectangle(int x1,int y1, int x2, int y2)
        {
            this.x1=x1;
            this.y1=y1;
            this.x2=x2;
            this.y2=y2;
        }
    }
    public class LegacyRectangleAdapter : IRectangle
    {
        private readonly LegacyRectangle _legacy;
        public LegacyRectangleAdapter(LegacyRectangle legacy)
        {
            _legacy=legacy;
        }
        public int x1
        {
            get => _legacy.x;
            set => _legacy.x=value;
        }
        public int y1
        {
            get => _legacy.y;
            set => _legacy.y=value;
        }
        public int x2
        {
            get => _legacy.x + _legacy.w;
            set => _legacy.w=value-_legacy.x;
        }
        public int y2
        {
            get => _legacy.y+ _legacy.h;
            set => _legacy.h=value-_legacy.y;
        }
    }
}




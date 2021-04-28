using System;

namespace InterfacesAndIPlugins
{
    public interface IPlugin
    {
        public void load();
        public void run();
        public void unload();

    }
    public interface IMetaData
    {
        public string getInfo();
    }
    public class PDFConverter : IPlugin, IMetaData //PDFConverter is the componenet
    {
        public string getInfo()
        {
            return "Author: Saleh";
        }

        public void load()
        {
            // throw new NotImplementedException();
            Console.WriteLine("PDF Converter has loaded..!");
        }

        public void run()
        {
            //throw new NotImplementedException();
            Console.WriteLine("PDF has been created..!");
        }

        public void unload()
        {
            //throw new NotImplementedException();
            Console.WriteLine("PDF Converter has unloaded..!");
        }
    }
    public class PageToImage : IPlugin //PageToImage is the componenet
    {
        public void load()
        {
            Console.WriteLine("Page To Image has loaded..!");
        }

        public void run()
        {
            Console.WriteLine("Page To Image has been created..!");
        }

        public void unload()
        {
            Console.WriteLine("Page To Image has unloaded..!");
        }
    }
    public class Translator : IPlugin //Translator is the componenet
    {
        public void load()
        {
            Console.WriteLine("Translator has loaded..!");
        }

        public void run()
        {
            Console.WriteLine("Translator has been created..!");
        }

        public void unload()
        {
            Console.WriteLine("Translator has unloaded..!");
        }
    }
    public class MyBrowser
    {
        public IPlugin[] plugins = new IPlugin[] { new PDFConverter(), new PageToImage(), new Translator() };
    public void start()
        {
            Console.WriteLine("I'm ready..");
            this.loadPlugins();
        }
        public void go(string address)
        {
            Console.WriteLine(address);
        }
        public void end()
        {
            this.unloadPlugins();
            Console.WriteLine("All done..");
        }
        // Methods:
        public void loadPlugins()
        {
            foreach(var plugin in this.plugins)
            {
                plugin.load(); // also Polymorphism
            }
        }
        public void runPlugins(IPlugin plugin)
        {
            plugin.run(); // It's for PDFConverter, PageToImage and then the Translator (Polymorphism)
        }
        public void unloadPlugins()
        {
            foreach (var plugin in this.plugins)
            {
                plugin.unload(); // also Polymorphism
            }
        }
        /*
         
         
         */
        public void printPluginMetta(IMetaData metaData)
        {
            Console.WriteLine(metaData.getInfo());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyBrowser mb = new MyBrowser();
            mb.start();
            //mb.loadPlugins();
            //mb.runPlugins();
            //mb.unloadPlugins();
            mb.end();


            Console.ReadKey();
        }
    }
}

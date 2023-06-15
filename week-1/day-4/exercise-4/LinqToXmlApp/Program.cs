using System;
using System.Linq;
using System.Xml.Linq;



namespace LinqToXmlApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assume there is an XML document with the following structure:
            // <Books>
            //     <Book>
            //         <Title>Book Title 1</Title>
            //         <Author>Author 1</Author>
            //         <Genre>Genre 1</Genre>
            //     </Book>
            //     ...
            // </Books>
            // Write above book structure as a c# string
            string xmlString = @"<Books>
                                    <Book>
                                        <Title>The Shining</Title>
                                        <Author>Narayana Murthy</Author>
                                        <Genre>Thriller</Genre>
                                    </Book>
                                    <Book>
                                        <Title>The Hunger Games</Title>
                                        <Author>Stephan king</Author>
                                        <Genre>Dystopian</Genre>
                                    </Book>
                                    <Book>
                                        <Title>The Notebook</Title>
                                        <Author>Nicholas Spark</Author>
                                        <Genre>Romance</Genre>
                                    </Book>
                                </Books>";

            // Create an XDocument object from the XML string

            XDocument xmlDoc = XDocument.Parse(xmlString);


            // Write the title of all books to the console
           
            var allTitles = xmlDoc.Descendants("Title").Select(t => t.Value);
            Console.WriteLine("All Book Titles:");
            foreach (var title in allTitles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();



            // Write the title of all books with genre "Genre 1" to the console

            var genre1Titles = xmlDoc.Descendants("Book")
                .Where(b => (string)b.Element("Genre") == "Romance")
                .Select(b => (string)b.Element("Title"));
            Console.WriteLine("Book Titles with Romance:");
            foreach (var title in genre1Titles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
        }
    }
}
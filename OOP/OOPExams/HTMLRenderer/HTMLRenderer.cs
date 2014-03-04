using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }
        string TextContent { get; set; }
        IEnumerable<IElement> ChildElements { get; }
        void AddElement(IElement element);
        void Render(StringBuilder output);
        string ToString();
    }

    public class Element : IElement
    {
        private List<IElement> childElements;

        public Element(string name, string textContent)
        {
            this.Name = name;
            this.TextContent = textContent;
            this.childElements = new List<IElement>();
        }

        public Element(string name)
            : this(name, null) { }

        public string Name { get; private set; }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
        }

        public void AddElement(IElement element)
        {
            this.childElements.Add(element);
        }

        public void Render(StringBuilder output)
        {
            output.Append(string.Format("{0}{1}", this.Name == null ? "" : string.Format("<{0}>",this.Name)
                , this.TextContent == null ? "" : this.TextContent));

            if (this.childElements.Count != 0)
            {
                foreach (var tag in this.childElements)
                {
                    output.Append(tag.ToString());
                }
            }
            if (this.Name != null)
            {
                output.Append(string.Format("</{0}>", this.Name));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.Render(sb);
            return sb.ToString();
        }
    }

    public class Table : ITable
    {
        private IElement[,] elements;

        public Table(int rows, int columns)
        {
            this.Rows = rows;
            this.Cols = columns;
            this.elements = new IElement[rows, columns];
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public IElement this[int row, int col]
        {
            get
            {
                return this.elements[row, col];
            }
            set
            {
                this.elements[row, col] = value;
            }
        }

        public string Name
        {
            get { return "table"; }
        }

        public string TextContent
        {
            get
            {
                return string.Empty;
            }
            set
            {

            }
        }

        public IEnumerable<IElement> ChildElements
        {
            get { return new List<IElement>(); }
        }

        public void AddElement(IElement element)
        {

        }

        public void Render(StringBuilder output)
        {
            output.Append("<table>");

            for (int r = 0; r < this.Rows; r++)
            {
                output.Append("<tr>");
                for (int c = 0; c < this.Cols; c++)
                {
                    output.Append("<td>");
                    //render??
                    output.Append(this.elements[r, c].ToString());

                    output.Append("</td>");
                }
                output.Append("</tr>");
            }

            output.Append("</table>");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.Render(sb);

            return sb.ToString();
        }
    }

    public interface ITable : IElement
    {
        int Rows { get; }
        int Cols { get; }
        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);
        IElement CreateElement(string name, string content);
        ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new Element(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new Element(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new Table(rows, cols);
        }

        public class HTMLRendererCommandExecutor
        {
            static void Main()
            {
                string csharpCode = ReadInputCSharpCode();
                CompileAndRun(csharpCode);
            }

            private static string ReadInputCSharpCode()
            {
                StringBuilder result = new StringBuilder();
                string line;
                while ((line = Console.ReadLine()) != "")
                {
                    result.AppendLine(line);
                }
                return result.ToString();
            }

            static void CompileAndRun(string csharpCode)
            {
                // Prepare a C# program for compilation
                string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

                // Compile the C# program
                CompilerParameters compilerParams = new CompilerParameters();
                compilerParams.GenerateInMemory = true;
                compilerParams.TempFiles = new TempFileCollection(".");
                compilerParams.ReferencedAssemblies.Add("System.dll");
                compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
                CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
                CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                    compilerParams, csharpClass);

                // Check for compilation errors
                if (compile.Errors.HasErrors)
                {
                    string errorMsg = "Compilation error: ";
                    foreach (CompilerError ce in compile.Errors)
                    {
                        errorMsg += "\r\n" + ce.ToString();
                    }
                    throw new Exception(errorMsg);
                }

                // Invoke the Main() method of the compiled class
                Assembly assembly = compile.CompiledAssembly;
                Module module = assembly.GetModules()[0];
                Type type = module.GetType("RuntimeCompiledClass");
                MethodInfo methInfo = type.GetMethod("Main");
                methInfo.Invoke(null, null);
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace LojinhaLegal.Models.entity
{
    public class Produto
    {
        PrimaryKeyAttribute id;
        string name;
        string value;
        string description;
        public Produto() {
            this.name = string.Empty;
            this.value = string.Empty;
            this.description = string.Empty;
        }
        public Produto(string name, string value, string description)
        {
            this.name = name;
            this.value = value;
            this.description = description;
        }

        public string Name
        {
            get { return this.name; } set { this.name = value; }
        }


        public string Value
        {
            get { return this.value; } set {this.value = value; }

        }

        public string Description
        { get { return this.description; } set { this.description = value; } }


    }
}

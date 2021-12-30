using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    abstract public class Organization
    {
        private protected string nameOfOrganization;
        public Organization() { }
        public Organization(string orgName)
        {
            nameOfOrganization = orgName;
        }
        public string NameOfOrganization { get => nameOfOrganization; set => nameOfOrganization = value; }
        public abstract void Burning();
        public override string ToString() => $"Тип объекта – {this.GetType()}, название организации – {this.nameOfOrganization}";
    }
    public class Date
    {
        int year;
        int month;
        int day;
        public int Year { get => year; set => year = value; }
        public int Month
        {
            get => month;
            set
            {
                if (value < 1)
                    month = 1;
                else if (value > 12)
                    month = 12;
                else
                    month = value;
            }
        }
        public int Day
        {
            get => day;
            set
            {
                if (value < 1)
                    day = 1;
                else if (value > 31)
                    day = 31;
                else
                    day = value;
            }
        }
        public Date(int dateDay, int dateMonth, int dateYear)
        {
            Day = dateDay;
            Month = dateMonth;
            Year = dateYear;
        }
        public override string ToString() => $"Тип объекта – {this.GetType()}, дата создания: {day}.{month}.{year}";
    }
    public class Document : Organization
    {
        private protected bool stamp;
        private protected Date date;
        public bool IsStamped { get => stamp; set => stamp = value; }
        public Document(string organizationName, int dateDay, int dateMonth, int dateYear, bool isStamped)
            : base(organizationName)
        {
            date = new Date(dateDay, dateMonth, dateYear);
            stamp = isStamped;
        }

        // виртуальные методы, подлежащие переопределению

        virtual public void Store()
        {
            Console.WriteLine("Документ хранится в сейфе");
        }

        // реализация методов интерфейса

        public void Change()
        {
            Console.WriteLine("Документ изменен");
        }
        public void Find()
        {
            Console.WriteLine("Документ найден");
        }
        public void Lose()
        {
            Console.WriteLine("Документ утерян");
        }
        public override void Burning()
        {
            Console.WriteLine("О нет! Документ горит!");
        }

        // Переопределенные методы Object

        public override string ToString() => $"Тип объекта – {this.GetType()}, организация – {this.NameOfOrganization}, " +
            $"дата создания – {date.Day}.{date.Month}.{date.Year}, есть ли печать – " + (stamp ? "есть" : "нет");
        //public override int GetHashCode() => HashCode.Combine(this.NameOfOrganization, date.Day, date.Month, date.Year);
        public override bool Equals(object obj)
        {
            if (obj is Document objectType)
            {
                if (this.date.Day == objectType.date.Day
                        && this.date.Month == objectType.date.Month
                            && this.date.Year == objectType.date.Year
                                && this.NameOfOrganization == objectType.NameOfOrganization)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Receipt : Document //квитанция
    {
        private protected string docType;
        public string DocType { get => docType; set => docType = value; }
        public Receipt(string organizationName, int dateDay, int dateMonth, int dateYear, bool isStamped, string documentType)
            : base(organizationName, dateDay, dateMonth, dateYear, isStamped)
        {
            docType = documentType;
        }
        public override void Store()
        {
            Console.WriteLine("Этот документ хранится в ящике");
        }
        public override string ToString() => base.ToString() + $", тип документа – {this.DocType}";
    }
    public class Invoice : Document //накладная
    {
        private protected string docType;
        public string DocType { get => docType; set => docType = value; }
        public Invoice(string organizationName, int dateDay, int dateMonth, int dateYear, bool isStamped, string documentType)
            : base(organizationName, dateDay, dateMonth, dateYear, isStamped)
        {
            docType = documentType;
        }
        public override void Store()
        {
            Console.WriteLine("Этот документ хранится на полке");
        }
        public override string ToString() => base.ToString() + $", тип документа – {this.DocType}";
    }
    sealed public class Check : Document   //чек
    {
        private string docType;
        public string DocType { get => docType; set => docType = value; }
        public Check(string organizationName, int dateDay, int dateMonth, int dateYear, bool isStamped, string documentType)
            : base(organizationName, dateDay, dateMonth, dateYear, isStamped)
        {
            docType = documentType;
        }
        public override void Store()
        {
            Console.WriteLine("Этот документ хранится в стопке");
        }
        public override string ToString() => base.ToString() + $", тип документа – {this.DocType}";
    }
    public class Printer
    {
        public void IAmPrinting(Organization someobj)
        {
            Console.WriteLine(someobj.ToString());
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{

    // Abstract classes allow you to create a sort of prototype of an object for other classes to inherit from. 
    // You can define concrete implimentations of properties, values, and methods, but you can also leave them 
    // undefined to be implimented on other more specific version of the class.
    public abstract class GradeTracker : IGradeTracker
    {
        // This method is declared as abstract because it will not be defined here. It will need to be defined in
        // a subsequent class that inherits from GradeTracker using the override keyword. Note the type here is
        // and must be defined, and any subsequent definitions will need to have the same type (or be derived from
        // this type.)
        public abstract void AddGrade(float grade);

        // Same as above - this is an abstract method, however, it returns a GradeStatistics type.
        public abstract GradeStatistics ComputeStatistics();

        public abstract void WriteGrades(TextWriter destination);

        // Publicly accessible property. Note the uppercase naming convention indicating it is public, and use of
        // get/set declarations.
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidDataException("Name cannot be null or empty.");
                }

                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();

                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }

                _name = value;
            }
        }

        // The underlying value of the Name property. It has been made protected to make the value accessible to
        // derived classes. (Classes that inherit from this abstract class)
        protected string _name;

        // This is an event of the type NameChangedDelegate. This is the event to which actions can be bound.
        // Once the event is triggered, the bound actions will execute.
        public event NameChangedDelegate NameChanged;

    }
}

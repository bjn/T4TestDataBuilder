 
 
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestDataBuilder {

  
  public partial class CarBuilder {
    public CarBuilder() {
						_year = DefaultValueFactory.GetValue(() => _year);
							_name = DefaultValueFactory.GetValue(() => _name);
				}
  
			private int _year;
			private string _name;
	
			public CarBuilder WithYear(int year) {
			_year = year;
			return this;
		}
			public CarBuilder WithName(string name) {
			_name = name;
			return this;
		}
	
	public T4TestDataBuilder.Entities.Scenario1.Car Build() {
		return new T4TestDataBuilder.Entities.Scenario1.Car {
												Year = _year,
																Name = _name,
									};
	}

	public static implicit operator T4TestDataBuilder.Entities.Scenario1.Car(CarBuilder builder) {
		return builder.Build();
	}


  } // end class

 
 public class BuilderList<T> : List<T>
    {
        public IEnumerable<Y> ToList<Y>() where Y : class
        {
            return this.Select(item => item as Y);
        }
    }
	
	public class DefaultValueFactory
    {
         public static T GetValue<T>(Expression<Func<T>> expr)
         {
             if (expr.Body.Type == typeof(string))
             {
                 return (T)(object)(expr.Body as MemberExpression).Member.Name;

             }
             return default(T);
         }
    }
} // end namespace


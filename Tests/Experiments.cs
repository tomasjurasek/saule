﻿using Saule;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Experiments
    {
        [Fact]
        public void Run()
        {
            var person = new Person();
            var response = person.ToApiResponse(typeof(OtherModel));
            var json = response.ToJson();

            Assert.True(true);
        }
    }

    public class PersonModel : ApiResource
    {
        public PersonModel()
        {
            WithAttribute("firstName");
            WithAttribute("lastName");
            WithAttribute("age");

            BelongsTo("father", typeof(PersonModel));
            BelongsTo("mother", typeof(PersonModel));

            HasMany("siblings", typeof(PersonModel));
        }
    }

    public class OtherModel : PersonModel { }

    public class Person
    {
        public string FirstName => "John";
        public string LastName => "Smith";
        public int Age => 45;

        public Person Father => null;
        public Person Mother => null;

        public IEnumerable<Person> Siblings => new List<Person>();
    }
}
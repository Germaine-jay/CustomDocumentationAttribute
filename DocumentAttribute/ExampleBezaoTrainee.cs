using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentAttribute
{
    internal class ExampleBezaoTrainee
    {
    }
    [Document("A Software Engineering Trainee")]
    public class BEZAOTrainee
    {
        [Document("This initialises the Bezao Trainee with a full name",
            Input = "It takes the fullname as string")]

        public BEZAOTrainee(string fullname)
        {
            FullName = fullname;
        }


        [Document("This sets and gets  the Trainee's FullName")]
        public string FullName { get; set; }

        [Document("This sets and gets the Trainee's Age")]
        public string Age { get; set; }

        [Document("This Makes the Trainee quiet when something strange happens",
            Input = "It takes in an someThingsStrange as an object")]
        public void SomethingStrangeCode(object someThingStrange)
        {

        }

        [Document("This Makes the Trainee Code when an idea comes",
            Input = "It takes in an someThingsStrange as an object", Output = "It returns an object")]
        public void QuietCode(object someThingStrange)
        {

        }
    }

    [Document("A Software Engineering Training Program")]
    public class BEZAO
    {
        [Document("This initialises BEZAO with a cohort",
            Input = "It takes a cohort as string")]
        public void BEZAOTrainee(string cohort)
        {
            Cohort = cohort;
        }

        [Document("This sets and gets the BEZAO Cohort")]
        public string Cohort { get; set; }
    }

    [Document("These are what trainee screams")]
    public enum Scream
    {
        Omo,
        HeyGod,
        GodAbeg,
        OhShit
    }
}

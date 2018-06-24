using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebCalculator.Calculation.Coco2
{
    public static class Arithmetic
    {
        private static Uri addClientUri;
        private static Uri subClientUri;
        private static Uri multiClientUri;
        private static Uri divClientUri;

        static Arithmetic()
        {
            addClientUri = new Uri(@"http://add:8080");
            subClientUri = new Uri(@"http://sub:8080");
            multiClientUri = new Uri(@"http://multi:8080");
            divClientUri = new Uri(@"http://div:8080");
        }

        public static int Addition(int augend, int addend)
        {
            using (var addClient = new HttpClient() { BaseAddress = addClientUri }) {
                HttpResponseMessage response = addClient.PostAsJsonAsync("/", new { augend = augend, addend = addend }).Result;
                string contentResult = response.Content.ReadAsStringAsync().Result;
                JObject result = JObject.Parse(contentResult);
                return result.Value<int>("result");
            }
        }

        public static int Substraction(int minuend, int subtrahend)
        {
            return minuend - subtrahend;
        }

        public static int Multiplication(int multiplier, int mulitplicend)
        {
            return multiplier * mulitplicend;
        }

        public static int Division(int divend, int divisor)
        {
            return divend / divisor; 
        }
    }
}

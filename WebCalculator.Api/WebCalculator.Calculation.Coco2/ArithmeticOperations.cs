using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebCalculator.Calculation.Coco2
{
    public static class ArithmeticOperations
    {
        public static Uri uriAddClient;
        public static Uri uriSubClient;
        public static Uri uriMultiClient;
        public static Uri uriDivClient;

        public static int Addition(int augend, int addend)
        {
            using (var addClient = new HttpClient() { BaseAddress = uriAddClient }) {
                HttpResponseMessage response = addClient.PostAsJsonAsync("/", new { augend = augend, addend = addend }).Result;
                string contentResult = response.Content.ReadAsStringAsync().Result;
                JObject result = JObject.Parse(contentResult);
                return result.Value<int>("result");
            }
        }

        public static int Substraction(int minuend, int subtrahend)
        {
            using (var addClient = new HttpClient() { BaseAddress = uriSubClient })
            {
                HttpResponseMessage response = addClient
                    .PostAsJsonAsync("/", new { minuend = minuend, subtrahend = subtrahend }).Result;
                string contentResult = response.Content.ReadAsStringAsync().Result;
                JObject result = JObject.Parse(contentResult);
                return result.Value<int>("result");
            }
        }

        public static int Multiplication(int multiplier, int mulitiplicand)
        {
            using (var addClient = new HttpClient() { BaseAddress = uriMultiClient })
            {
                HttpResponseMessage response = addClient
                    .PostAsJsonAsync("/", new { multiplier = multiplier, mulitiplicand = mulitiplicand }).Result;
                string contentResult = response.Content.ReadAsStringAsync().Result;
                JObject result = JObject.Parse(contentResult);
                return result.Value<int>("result");
            }
        }

        public static int Division(int dividend, int divisor)
        {
            using (var addClient = new HttpClient() { BaseAddress = uriDivClient })
            {
                HttpResponseMessage response = addClient
                    .PostAsJsonAsync("/", new { dividend = dividend, divisor = divisor }).Result;
                string contentResult = response.Content.ReadAsStringAsync().Result;
                JObject result = JObject.Parse(contentResult);
                return result.Value<int>("result");
            }
        }
    }
}

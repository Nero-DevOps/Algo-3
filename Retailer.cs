using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Retailer
    {
        // variable declaration
        private String retailerName;
        private String storeName;
        private String streetName;
        private String town;
        private String postalCode;
        private String sizeBrand;
        private double xcordinate;
        private double ycordinate;

        // constructor 
        public Retailer(String retailerName, String storeName, String streetName, String town, String postalCode, String sizeBrand, double xcordinate, double ycordinate)
        {
            // initializing the instance variable 
            this.retailerName = retailerName;
            this.storeName = storeName;
            this.streetName = streetName;
            this.town = town;
            this.postalCode = postalCode;
            this.sizeBrand = sizeBrand;
            this.xcordinate = xcordinate;
            this.ycordinate = ycordinate;
        }
        // getter and setter 
        public double XCoordinate { get => xcordinate; set => xcordinate = value;}
        public double YCoordinate { get => ycordinate; set => ycordinate = value;}
        // define getter and setter function for retailer name
        public string RetailerName { get => retailerName; set => retailerName = value; }

        // define getter and setter function for store name
        public string StoreName { get => storeName; set => storeName = value; }

        // define getter and setter function for street name
        public string StreetName { get => streetName; set => streetName = value; }
        
        // define getter and setter function for town
        public string Town { get => town; set => town = value; }

        // define getter and setter for postal code
        public string PostalCode { get => postalCode; set => postalCode = value; }

        // define getter and setter for size band
        public string SizeBrand { get => sizeBrand; set => sizeBrand = value; }
    }
}

using Isas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Linq;

namespace Isas.Data
{
    public static class SeedData
    {
        //public static void Initialize(InsurerDbContext context)
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InsurerDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<InsurerDbContext>>()))
            {
                //  Look for any records on table Container
                if (context.Containers.Any())
                {
                    return;     //  DB has been seeded
                }

                //     context.Database.EnsureCreated();

                //// Check if Container table contains any records
                //if(context.Containers.Count() > 0)
                // {
                //     return; // DB has been seeded
                // }

                var countries = new Country[]
                {
                    new Country { Name="Pakistan",ISOCode="PAK",ISOCurrency="PKR",DialingCode=92},
                    new Country { Name="Syrian Arab Republic",ISOCode="SYR",ISOCurrency="SYP",DialingCode=963},
                    new Country { Name="Belgium",ISOCode="BEL",ISOCurrency="EUR",DialingCode=32},
                    new Country { Name="Benin",ISOCode="BEN",ISOCurrency="XOF",DialingCode=229},
                    new Country { Name="Namibia",ISOCode="NAM",ISOCurrency="NAD",DialingCode=264},
                    new Country { Name="Wallis and Futuna Islands",ISOCode="WLF",ISOCurrency="XPF",DialingCode=681},
                    new Country { Name="Mali",ISOCode="MLI",ISOCurrency="XOF",DialingCode=223},
                    new Country { Name="Liechtenstein", ISOCode="LIE",ISOCurrency="CHF",DialingCode=423},
                    new Country { Name="Cayman Islands",ISOCode="CYM",ISOCurrency="KYD",DialingCode=1},
                    new Country { Name="South Sudan", ISOCode="SSD",ISOCurrency="SSP",DialingCode=211},
                    new Country { Name="Cuba",ISOCode="CUB",ISOCurrency="CUP",DialingCode=53},
                    new Country { Name="Jersey",ISOCode="JEY",ISOCurrency="GBP",DialingCode=44},
                    new Country { Name="Guinea-bissau", ISOCode="GNB",ISOCurrency="XOF",DialingCode=245},
                    new Country { Name="Guam",ISOCode="GUM",ISOCurrency="USD",DialingCode=1},
                    new Country { Name="Hungary", ISOCode="HUN",ISOCurrency="HUF",DialingCode=36},
                    new Country { Name="Canada",ISOCode="CAN",ISOCurrency="CAD",DialingCode=1},
                    new Country { Name="Brunei Darussalam", ISOCode="BRN",ISOCurrency="BND",DialingCode=673},
                    new Country { Name="Tonga", ISOCode="TON",ISOCurrency="TOP",DialingCode=676},
                    new Country { Name="New Caledonia", ISOCode="NCL",ISOCurrency="XPF",DialingCode=687},
                    new Country { Name="Central African Republic",ISOCode="CAF",ISOCurrency="XAF",DialingCode=236},
                    new Country { Name="Finland", ISOCode="FIN",ISOCurrency="EUR",DialingCode=358},
                    new Country { Name="United Republic of Tanzania",ISOCode="TZA",ISOCurrency="TZS",DialingCode=255},
                    new Country { Name="Egypt", ISOCode="EGY",ISOCurrency="EGP",DialingCode=20},
                    new Country { Name="Cook Islands",ISOCode="COK",ISOCurrency="NZD",DialingCode=682},
                    new Country { Name="Turks and Caicos Islands",ISOCode="TCA",ISOCurrency="USD",DialingCode=1},
                    new Country { Name="Martinique",ISOCode="MTQ",ISOCurrency="EUR",DialingCode=0},
                    new Country { Name="Tajikistan",ISOCode="TJK",ISOCurrency="TJS",DialingCode=992},
                    new Country { Name="Sint Maarten ", ISOCode="SXM",ISOCurrency="ANG",DialingCode=1},
                    new Country { Name="Libya", ISOCode="LBY",ISOCurrency="LYD",DialingCode=218},
                    new Country { Name="Republic of Moldova", ISOCode="MDA",ISOCurrency="MDL",DialingCode=373},
                    new Country { Name="Switzerland", ISOCode="CHE",ISOCurrency="CHF",DialingCode=41},
                    new Country { Name="Guinea",ISOCode="GIN",ISOCurrency="GNF",DialingCode=224},
                    new Country { Name="Portugal",ISOCode="PRT",ISOCurrency="EUR",DialingCode=351},
                    new Country { Name="Serbia",ISOCode="SRB",ISOCurrency="RSD",DialingCode=381},
                    new Country { Name="Trinidad and Tobago", ISOCode="TTO",ISOCurrency="TTD",DialingCode=1},
                    new Country { Name="Gambia",ISOCode="GMB",ISOCurrency="GMD",DialingCode=220},
                    new Country { Name="Sweden",ISOCode="SWE",ISOCurrency="SEK",DialingCode=46},
                    new Country { Name="State of Palestine",ISOCode="PSE",ISOCurrency=DBNull.Value.ToString(),DialingCode=970},
                    new Country { Name="Kyrgyzstan",ISOCode="KGZ",ISOCurrency="KGS",DialingCode=996},
                    new Country { Name="Iraq",ISOCode="IRQ",ISOCurrency="IQD",DialingCode=964},
                    new Country { Name="Virgin Islands (British)",ISOCode="VGB",ISOCurrency="USD",DialingCode=1},
                    new Country { Name="Australia", ISOCode="AUS",ISOCurrency="AUD",DialingCode=61},
                    new Country { Name="Niue",ISOCode="NIU",ISOCurrency="NZD",DialingCode=683},
                    new Country { Name="Réunion", ISOCode="REU",ISOCurrency="EUR",DialingCode=262},
                    new Country { Name="Kuwait",ISOCode="KWT",ISOCurrency="KWD",DialingCode=965},
                    new Country { Name="Togo",ISOCode="TGO",ISOCurrency="XOF",DialingCode=228},
                    new Country { Name="Mexico",ISOCode="MEX",ISOCurrency="MXN",DialingCode=52},
                    new Country { Name="Argentina", ISOCode="ARG",ISOCurrency="ARS",DialingCode=54},
                    new Country { Name="South Africa",ISOCode="ZAF",ISOCurrency="ZAR",DialingCode=27,Tax=decimal.Parse("14")},
                    new Country { Name="United States Minor Outlying Islands",ISOCode="UMI",ISOCurrency=DBNull.Value.ToString(),DialingCode=0},
                    new Country { Name="India", ISOCode="IND",ISOCurrency="INR",DialingCode=91},
                    new Country { Name="Sri Lanka", ISOCode="LKA",ISOCurrency="LKR",DialingCode=94},
                    new Country { Name="Marshall Islands",ISOCode="MHL",ISOCurrency="USD",DialingCode=692},
                    new Country { Name="United Arab Emirates",ISOCode="ARE",ISOCurrency="AED",DialingCode=971},
                    new Country { Name="Kazakhstan",ISOCode="KAZ",ISOCurrency="KZT",DialingCode=7},
                    new Country { Name="Bouvet Island", ISOCode="BVT",ISOCurrency=DBNull.Value.ToString(),DialingCode=0},
                    new Country { Name="Saudi Arabia",ISOCode="SAU",ISOCurrency="SAR",DialingCode=966},
                    new Country { Name="Paraguay",ISOCode="PRY",ISOCurrency="PYG",DialingCode=595},
                    new Country { Name="Tokelau", ISOCode="TKL",ISOCurrency="NZD",DialingCode=690},
                    new Country { Name="Belarus", ISOCode="BLR",ISOCurrency="BYR",DialingCode=375},
                    new Country { Name="Malawi",ISOCode="MWI",ISOCurrency="MWK",DialingCode=265},
                    new Country { Name="Western Sahara",ISOCode="ESH",ISOCurrency="MAD",DialingCode=212},
                    new Country { Name="British Indian Ocean Territory",ISOCode="IOT",ISOCurrency=DBNull.Value.ToString(),DialingCode=246},
                    new Country { Name="Bhutan",ISOCode="BTN",ISOCurrency="INR",DialingCode=975},
                    new Country { Name="Guatemala", ISOCode="GTM",ISOCurrency="GTQ",DialingCode=502},
                    new Country { Name="Mayotte", ISOCode="MYT",ISOCurrency="EUR",DialingCode=262},
                    new Country { Name="Austria", ISOCode="AUT",ISOCurrency="EUR",DialingCode=43},
                    new Country { Name="Norfolk Island",ISOCode="NFK",ISOCurrency="AUD",DialingCode=0},
                    new Country { Name="Denmark", ISOCode="DNK",ISOCurrency="DKK",DialingCode=45},
                    new Country { Name="Netherlands", ISOCode="NLD",ISOCurrency="EUR",DialingCode=31},
                    new Country { Name="Japan", ISOCode="JPN",ISOCurrency="JPY",DialingCode=81},
                    new Country { Name="Italy", ISOCode="ITA",ISOCurrency="EUR",DialingCode=39},
                    new Country { Name="Republic of Korea", ISOCode="KOR",ISOCurrency="KRW",DialingCode=82},
                    new Country { Name="Saint Vincent and The Grenadines",ISOCode="VCT",ISOCurrency="XCD",DialingCode=1},
                    new Country { Name="Plurinational State of Bolivia",ISOCode="BOL",ISOCurrency="BOB",DialingCode=591},
                    new Country { Name="Rwanda",ISOCode="RWA",ISOCurrency="RWF",DialingCode=250},
                    new Country { Name="Comoros", ISOCode="COM",ISOCurrency="KMF",DialingCode=269},
                    new Country { Name="Panama",ISOCode="PAN",ISOCurrency="USD",DialingCode=507},
                    new Country { Name="Bulgaria",ISOCode="BGR",ISOCurrency="BGN",DialingCode=359},
                    new Country { Name="Bahamas", ISOCode="BHS",ISOCurrency="BSD",DialingCode=1},
                    new Country { Name="Curaçao", ISOCode="CUW",ISOCurrency="ANG",DialingCode=599},
                    new Country { Name="Iran ", ISOCode="IRN",ISOCurrency="IRR",DialingCode=98},
                    new Country { Name="China", ISOCode="CHN",ISOCurrency="CNY",DialingCode=86},
                    new Country { Name="Åland Islands", ISOCode="ALA",ISOCurrency="EUR",DialingCode=0},
                    new Country { Name="Peru",ISOCode="PER",ISOCurrency="PEN",DialingCode=51},
                    new Country { Name="Lesotho", ISOCode="LSO",ISOCurrency="ZAR",DialingCode=266},
                    new Country { Name="Cyprus",ISOCode="CYP",ISOCurrency="EUR",DialingCode=357},
                    new Country { Name="Sao Tome and Principe", ISOCode="STP",ISOCurrency="STD",DialingCode=239},
                    new Country { Name="United States", ISOCode="USA",ISOCurrency="USD",DialingCode=1},
                    new Country { Name="Colombia",ISOCode="COL",ISOCurrency="COP",DialingCode=57},
                    new Country { Name="Samoa", ISOCode="WSM",ISOCurrency="WST",DialingCode=685},
                    new Country { Name="Israel",ISOCode="ISR",ISOCurrency="ILS",DialingCode=972},
                    new Country { Name="Liberia", ISOCode="LBR",ISOCurrency="LRD",DialingCode=231},
                    new Country { Name="Vanuatu", ISOCode="VUT",ISOCurrency="VUV",DialingCode=678},
                    new Country { Name="Georgia", ISOCode="GEO",ISOCurrency="GEL",DialingCode=995},
                    new Country { Name="Tunisia", ISOCode="TUN",ISOCurrency="TND",DialingCode=216},
                    new Country { Name="Sint Eustatius and Saba Bonaire", ISOCode="BES",ISOCurrency="USD",DialingCode=0},
                    new Country { Name="Saint Kitts and Nevis", ISOCode="KNA",ISOCurrency="XCD",DialingCode=1},
                    new Country { Name="Costa Rica",ISOCode="CRI",ISOCurrency="CRC",DialingCode=506},
                    new Country { Name="Philippines", ISOCode="PHL",ISOCurrency="PHP",DialingCode=63},
                    new Country { Name="Tuvalu",ISOCode="TUV",ISOCurrency="AUD",DialingCode=688},
                    new Country { Name="Papua New Guinea",ISOCode="PNG",ISOCurrency="PGK",DialingCode=675},
                    new Country { Name="Angola",ISOCode="AGO",ISOCurrency="AOA",DialingCode=244},
                    new Country { Name="Virgin Islands (US)", ISOCode="VIR",ISOCurrency="USD",DialingCode=1},
                    new Country { Name="Anguilla",ISOCode="AIA",ISOCurrency="XCD",DialingCode=1},
                    new Country { Name="Christmas Island",ISOCode="CXR",ISOCurrency=DBNull.Value.ToString(),DialingCode=61},
                    new Country { Name="Uzbekistan",ISOCode="UZB",ISOCurrency="UZS",DialingCode=998},
                    new Country { Name="Burundi", ISOCode="BDI",ISOCurrency="BIF",DialingCode=257},
                    new Country { Name="Nigeria", ISOCode="NGA",ISOCurrency="NGN",DialingCode=234},
                    new Country { Name="Macao", ISOCode="MAC",ISOCurrency="MOP",DialingCode=853},
                    new Country { Name="Barbados",ISOCode="BRB",ISOCurrency="BBD",DialingCode=1},
                    new Country { Name="Ecuador", ISOCode="ECU",ISOCurrency="USD",DialingCode=593},
                    new Country { Name="Albania", ISOCode="ALB",ISOCurrency="ALL",DialingCode=355},
                    new Country { Name="Ascension and Tristan Da Cunha Saint Helena", ISOCode="SHN",ISOCurrency="SHP",DialingCode=290},
                    new Country { Name="Zimbabwe",ISOCode="ZWE",ISOCurrency="ZWL",DialingCode=263},
                    new Country { Name="Honduras",ISOCode="HND",ISOCurrency="HNL",DialingCode=504},
                    new Country { Name="Lao People's Democratic Republic",ISOCode="LAO",ISOCurrency="LAK",DialingCode=856},
                    new Country { Name="Antarctica",ISOCode="ATA",ISOCurrency=DBNull.Value.ToString(),DialingCode=672},
                    new Country { Name="Bahrain", ISOCode="BHR",ISOCurrency="BHD",DialingCode=973},
                    new Country { Name="Bolivarian Republic of Venezuela",ISOCode="VEN",ISOCurrency="VEF",DialingCode=58},
                    new Country { Name="Botswana",ISOCode="BWA",ISOCurrency="BWP",DialingCode=267,Tax=decimal.Parse("12")},
                    new Country { Name="Suriname",ISOCode="SUR",ISOCurrency="SRD",DialingCode=597},
                    new Country { Name="Burkina Faso",ISOCode="BFA",ISOCurrency="XOF",DialingCode=226},
                    new Country { Name="Thailand",ISOCode="THA",ISOCurrency="THB",DialingCode=66},
                    new Country { Name="Montenegro",ISOCode="MNE",ISOCurrency="EUR",DialingCode=382},
                    new Country { Name="Province of China Taiwan",ISOCode="TWN",ISOCurrency=DBNull.Value.ToString(),DialingCode=886},
                    new Country { Name="French Southern Territories", ISOCode="ATF",ISOCurrency=DBNull.Value.ToString(),DialingCode=0},
                    new Country { Name="France",ISOCode="FRA",ISOCurrency="EUR",DialingCode=33},
                    new Country { Name="Mauritius", ISOCode="MUS",ISOCurrency="MUR",DialingCode=230},
                    new Country { Name="Oman",ISOCode="OMN",ISOCurrency="OMR",DialingCode=968},
                    new Country { Name="Maldives",ISOCode="MDV",ISOCurrency="MVR",DialingCode=960},
                    new Country { Name="Greece",ISOCode="GRC",ISOCurrency="EUR",DialingCode=30},
                    new Country { Name="Croatia ",ISOCode="HRV",ISOCurrency="HRK",DialingCode=385},
                    new Country { Name="Falkland Islands ", ISOCode="FLK",ISOCurrency="FKP",DialingCode=500},
                    new Country { Name="Democratic People's Republic of Korea", ISOCode="PRK",ISOCurrency="KPW",DialingCode=850},
                    new Country { Name="Gibraltar", ISOCode="GIB",ISOCurrency="GIP",DialingCode=350},
                    new Country { Name="Madagascar",ISOCode="MDG",ISOCurrency="MGA",DialingCode=261},
                    new Country { Name="Brazil",ISOCode="BRA",ISOCurrency="BRL",DialingCode=55},
                    new Country { Name="Equatorial Guinea", ISOCode="GNQ",ISOCurrency="XAF",DialingCode=240},
                    new Country { Name="Palau", ISOCode="PLW",ISOCurrency="USD",DialingCode=680},
                    new Country { Name="Jamaica", ISOCode="JAM",ISOCurrency="JMD",DialingCode=1},
                    new Country { Name="Kenya", ISOCode="KEN",ISOCurrency="KES",DialingCode=254},
                    new Country { Name="San Marino",ISOCode="SMR",ISOCurrency="EUR",DialingCode=378},
                    new Country { Name="Uganda",ISOCode="UGA",ISOCurrency="UGX",DialingCode=256},
                    new Country { Name="United Kingdom",ISOCode="GBR",ISOCurrency="GBP",DialingCode=44},
                    new Country { Name="Kiribati",ISOCode="KIR",ISOCurrency="AUD",DialingCode=686},
                    new Country { Name="Chile", ISOCode="CHL",ISOCurrency="CLP",DialingCode=56},
                    new Country { Name="Ireland", ISOCode="IRL",ISOCurrency="EUR",DialingCode=353},
                    new Country { Name="Myanmar", ISOCode="MMR",ISOCurrency="MMK",DialingCode=95},
                    new Country { Name="Seychelles",ISOCode="SYC",ISOCurrency="SCR",DialingCode=248},
                    new Country { Name="Mongolia",ISOCode="MNG",ISOCurrency="MNT",DialingCode=976},
                    new Country { Name="Cameroon",ISOCode="CMR",ISOCurrency="XAF",DialingCode=237},
                    new Country { Name="El Salvador", ISOCode="SLV",ISOCurrency="USD",DialingCode=503},
                    new Country { Name="Slovenia",ISOCode="SVN",ISOCurrency="EUR",DialingCode=386},
                    new Country { Name="Dominican Republic",ISOCode="DOM",ISOCurrency="DOP",DialingCode=1},
                    new Country { Name="Somalia", ISOCode="SOM",ISOCurrency="SOS",DialingCode=252},
                    new Country { Name="Lebanon", ISOCode="LBN",ISOCurrency="LBP",DialingCode=961},
                    new Country { Name="Faroe Islands", ISOCode="FRO",ISOCurrency=DBNull.Value.ToString(),DialingCode=298},
                    new Country { Name="Morocco", ISOCode="MAR",ISOCurrency="MAD",DialingCode=212},
                    new Country { Name="Qatar", ISOCode="QAT",ISOCurrency="QAR",DialingCode=974},
                    new Country { Name="Heard and McDonald Islands",ISOCode="HMD",ISOCurrency=DBNull.Value.ToString(),DialingCode=0},
                    new Country { Name="Hong Kong", ISOCode="HKG",ISOCurrency=DBNull.Value.ToString(),DialingCode=852},
                    new Country { Name="Slovakia",ISOCode="SVK",ISOCurrency="EUR",DialingCode=421},
                    new Country { Name="Bermuda", ISOCode="BMU",ISOCurrency="BMD",DialingCode=1},
                    new Country { Name="Northern Mariana Islands",ISOCode="MNP",ISOCurrency="USD",DialingCode=1},
                    new Country { Name="Czech Republic",ISOCode="CZE",ISOCurrency="CZK",DialingCode=420},
                    new Country { Name="Isle of Man", ISOCode="IMN",ISOCurrency="GBP",DialingCode=44},
                    new Country { Name="Malta", ISOCode="MLT",ISOCurrency="EUR",DialingCode=356},
                    new Country { Name="Guyana",ISOCode="GUY",ISOCurrency="GYD",DialingCode=592},
                    new Country { Name="New Zealand", ISOCode="NZL",ISOCurrency="NZD",DialingCode=64},
                    new Country { Name="Andorra", ISOCode="AND",ISOCurrency="EUR",DialingCode=376},
                    new Country { Name="Nicaragua", ISOCode="NIC",ISOCurrency="NIO",DialingCode=505},
                    new Country { Name="Pitcairn",ISOCode="PCN",ISOCurrency="NZD",DialingCode=64},
                    new Country { Name="Ethiopia",ISOCode="ETH",ISOCurrency="ETB",DialingCode=251},
                    new Country { Name="Singapore", ISOCode="SGP",ISOCurrency="SGD",DialingCode=65},
                    new Country { Name="Bosnia and Herzegowina",ISOCode="BIH",ISOCurrency="BAM",DialingCode=387},
                    new Country { Name="Ghana", ISOCode="GHA",ISOCurrency="GHS",DialingCode=233},
                    new Country { Name="Federated States of Micronesia",ISOCode="FSM",ISOCurrency="USD",DialingCode=691},
                    new Country { Name="Iceland", ISOCode="ISL",ISOCurrency="ISK",DialingCode=354},
                    new Country { Name="Swaziland", ISOCode="SWZ",ISOCurrency="SZL",DialingCode=268},
                    new Country { Name="Armenia", ISOCode="ARM",ISOCurrency="AMD",DialingCode=374},
                    new Country { Name="Indonesia", ISOCode="IDN",ISOCurrency="IDR",DialingCode=62},
                    new Country { Name="Sudan", ISOCode="SDN",ISOCurrency="SDG",DialingCode=249},
                    new Country { Name="Jordan",ISOCode="JOR",ISOCurrency="JOD",DialingCode=962},
                    new Country { Name="Monaco",ISOCode="MCO",ISOCurrency="EUR",DialingCode=377},
                    new Country { Name="Nepal", ISOCode="NPL",ISOCurrency="NPR",DialingCode=977},
                    new Country { Name="Luxembourg",ISOCode="LUX",ISOCurrency="EUR",DialingCode=352},
                    new Country { Name="Djibouti",ISOCode="DJI",ISOCurrency="DJF",DialingCode=253},
                    new Country { Name="Gabon", ISOCode="GAB",ISOCurrency="XAF",DialingCode=241},
                    new Country { Name="French Guiana", ISOCode="GUF",ISOCurrency="EUR",DialingCode=0},
                    new Country { Name="Eritrea", ISOCode="ERI",ISOCurrency="ERN",DialingCode=291},
                    new Country { Name="Haiti", ISOCode="HTI",ISOCurrency="USD",DialingCode=509},
                    new Country { Name="Uruguay", ISOCode="URY",ISOCurrency="UYU",DialingCode=598},
                    new Country { Name="Algeria", ISOCode="DZA",ISOCurrency="DZD",DialingCode=213},
                    new Country { Name="The Democratic Republic of The Congo",ISOCode="COD",ISOCurrency=DBNull.Value.ToString(),DialingCode=243},
                    new Country { Name="Norway",ISOCode="NOR",ISOCurrency="NOK",DialingCode=47},
                    new Country { Name="Nauru", ISOCode="NRU",ISOCurrency="AUD",DialingCode=674},
                    new Country { Name="Montserrat",ISOCode="MSR",ISOCurrency="XCD",DialingCode=1},
                    new Country { Name="Belize",ISOCode="BLZ",ISOCurrency="BZD",DialingCode=501},
                    new Country { Name="American Samoa",ISOCode="ASM",ISOCurrency="USD",DialingCode=1},
                    new Country { Name="Saint Lucia", ISOCode="LCA",ISOCurrency="XCD",DialingCode=1},
                    new Country { Name="The Former Yugoslav Republic of Macedonia", ISOCode="MKD",ISOCurrency="MKD",DialingCode=389},
                    new Country { Name="Azerbaijan",ISOCode="AZE",ISOCurrency="AZN",DialingCode=994},
                    new Country { Name="Romania", ISOCode="ROU",ISOCurrency="RON",DialingCode=40},
                    new Country { Name="Holy See ", ISOCode="VAT",ISOCurrency="EUR",DialingCode=379},
                    new Country { Name="Chad",ISOCode="TCD",ISOCurrency="XAF",DialingCode=235},
                    new Country { Name="Senegal", ISOCode="SEN",ISOCurrency="XOF",DialingCode=221},
                    new Country { Name="Antigua and Barbuda", ISOCode="ATG",ISOCurrency="XCD",DialingCode=1},
                    new Country { Name="Latvia",ISOCode="LVA",ISOCurrency="EUR",DialingCode=371},
                    new Country { Name="Yemen", ISOCode="YEM",ISOCurrency="YER",DialingCode=967},
                    new Country { Name="Mauritania",ISOCode="MRT",ISOCurrency="MRO",DialingCode=222},
                    new Country { Name="Saint Pierre and Miquelon", ISOCode="SPM",ISOCurrency="EUR",DialingCode=508},
                    new Country { Name="CocosIslands",ISOCode="CCK",ISOCurrency=DBNull.Value.ToString(),DialingCode=61},
                    new Country { Name="Sierra Leone",ISOCode="SLE",ISOCurrency="SLL",DialingCode=232},
                    new Country { Name="Puerto Rico", ISOCode="PRI",ISOCurrency="USD",DialingCode=1},
                    new Country { Name="Timor-leste", ISOCode="TLS",ISOCurrency="USD",DialingCode=670},
                    new Country { Name="Vietnam", ISOCode="VNM",ISOCurrency="VND",DialingCode=84},
                    new Country { Name="Poland",ISOCode="POL",ISOCurrency="PLN",DialingCode=48},
                    new Country { Name="Spain", ISOCode="ESP",ISOCurrency="EUR",DialingCode=34},
                    new Country { Name="Cambodia",ISOCode="KHM",ISOCurrency="KHR",DialingCode=855},
                    new Country { Name="Grenada", ISOCode="GRD",ISOCurrency="XCD",DialingCode=1},
                    new Country { Name="Dominica",ISOCode="DMA",ISOCurrency="XCD",DialingCode=1},
                    new Country { Name="Greenland", ISOCode="GRL",ISOCurrency="DKK",DialingCode=299},
                    new Country { Name="Afghanistan", ISOCode="AFG",ISOCurrency="AFN",DialingCode=93},
                    new Country { Name="Lithuania", ISOCode="LTU",ISOCurrency="EUR",DialingCode=370},
                    new Country { Name="Guadeloupe",ISOCode="GLP",ISOCurrency="EUR",DialingCode=0},
                    new Country { Name="Bangladesh",ISOCode="BGD",ISOCurrency="BDT",DialingCode=880},
                    new Country { Name="Russian Federation",ISOCode="RUS",ISOCurrency="RUB",DialingCode=7},
                    new Country { Name="Estonia", ISOCode="EST",ISOCurrency="EUR",DialingCode=372},
                    new Country { Name="Solomon Islands", ISOCode="SLB",ISOCurrency="SBD",DialingCode=677},
                    new Country { Name="South Georgia and The South Sandwich Islands",ISOCode="SGS",ISOCurrency=DBNull.Value.ToString(),DialingCode=0},
                    new Country { Name="French Polynesia",ISOCode="PYF",ISOCurrency="XPF",DialingCode=689},
                    new Country { Name="Cape Verde",ISOCode="CPV",ISOCurrency="CVE",DialingCode=238},
                    new Country { Name="Fiji",ISOCode="FJI",ISOCurrency="FJD",DialingCode=679},
                    new Country { Name="Aruba", ISOCode="ABW",ISOCurrency="AWG",DialingCode=297},
                    new Country { Name="Malaysia",ISOCode="MYS",ISOCurrency="MYR",DialingCode=60},
                    new Country { Name="Saint Barthélemy",ISOCode="BLM",ISOCurrency="EUR",DialingCode=590},
                    new Country { Name="Germany", ISOCode="DEU",ISOCurrency="EUR",DialingCode=49},
                    new Country { Name="Turkmenistan",ISOCode="TKM",ISOCurrency="TMT",DialingCode=993},
                    new Country { Name="Svalbard and Jan Mayen Islands",ISOCode="SJM",ISOCurrency="NOK",DialingCode=47},
                    new Country { Name="Congo", ISOCode="COG",ISOCurrency="XAF",DialingCode=242},
                    new Country { Name="Mozambique",ISOCode="MOZ",ISOCurrency="MZN",DialingCode=258},
                    new Country { Name="Niger", ISOCode="NER",ISOCurrency="XOF",DialingCode=227},
                    new Country { Name="NotApplicable", ISOCode="N/A",ISOCurrency="N/A",DialingCode=0,Tax=decimal.Parse("0")},
                    new Country { Name="Guernsey",ISOCode="GGY",ISOCurrency="GBP",DialingCode=44},
                    new Country { Name="Turkey",ISOCode="TUR",ISOCurrency="TRY",DialingCode=90},
                    new Country { Name="Ukraine", ISOCode="UKR",ISOCurrency="UAH",DialingCode=380},
                    new Country { Name="Zambia",ISOCode="ZMB",ISOCurrency="ZMW",DialingCode=260,Tax=decimal.Parse("16")},
                    new Country { Name="Côte d'Ivoire", ISOCode="CIV",ISOCurrency="XOF",DialingCode=225}
                                };
                foreach (Country c in countries)
                {
                    context.Countries.Add(c);
                }
                context.SaveChanges();

                var provinces = new Province[]
                {
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="Central"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="Chobe"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="Ghanzi"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="Kgalagadi"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="Kgatleng"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="Kweneng"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="Ngamiland"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="North-East"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="South-East"},
                    new Province {CountryID=countries.Single(p => p.Name == "Botswana").ID,Name="Southern"},
                };
                foreach (Province p in provinces)
                {
                    context.Provinces.Add(p);
                }
                context.SaveChanges();

                var accountcharts = new AccountChart[]
                {
                   new AccountChart { AccountCode="1020",Description="Sale of Salvage",IncomeOrExpense=1},
                   new AccountChart { AccountCode="1030",Description="Payment of Excess",IncomeOrExpense=1},
                   new AccountChart { AccountCode="1050",Description="Third Party Recoveries",IncomeOrExpense=1},
                   new AccountChart { AccountCode="2010",Description="Write Off",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2015",Description="Excess Reimbursement",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2020",Description="Motor Vehicle Repairs",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2030",Description="Theft",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2040",Description="Third Party Motor",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2050",Description="Towing",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2060",Description="Assessors Fees",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2070",Description="Police Report",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2075",Description="Legal or Tracing Fees",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2080",Description="Medical Expenses",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2105",Description="VAT Input",IncomeOrExpense=1},
                   new AccountChart { AccountCode="2110",Description="VAT Output",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2010",Description="Write Off",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2210",Description="Claims Preparation",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2220",Description="Debris Removal",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2230",Description="Fire Damage",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2240",Description="Political Riot",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2250",Description="Money",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2260",Description="Fidelity Cover",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2270",Description="Public Liability",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2280",Description="CAR",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="2290",Description="WCA",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="4040",Description="Sundry Creditors",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="5500",Description="Premium Refund",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="7030",Description="House Repairs",IncomeOrExpense=-1},
                   new AccountChart { AccountCode="7035",Description="Third Party House",IncomeOrExpense=-1}
                };
                foreach (AccountChart a in accountcharts)
                {
                    context.AccountCharts.Add(a);
                }
                context.SaveChanges();

                var banks = new Bank[]
                {
                   new Bank { Name="BancABC",PayeeClassID=2,Payable=false },
                   new Bank { Name="Bank Gaborone Limited",PayeeClassID=2,Payable=false },
                   new Bank { Name="ABN AMRO BANK",PayeeClassID=2,Payable=false },
                   new Bank { Name="Bank of Baroda (Botswana) Limited",PayeeClassID=2,Payable=false },
                   new Bank { Name="Bank of Botswana",PayeeClassID=2,Payable=false },
                   new Bank { Name="Bank of India (Botswana) Limited",PayeeClassID=2,Payable=false },
                   new Bank { Name="Barclays Bank of Botswana Limited",PayeeClassID=2,Payable=false },
                   new Bank { Name="Capital Bank Limited",PayeeClassID=2,Payable=false },
                   new Bank { Name="First National Bank of Botswana Limited",PayeeClassID=2,Payable=false },
                   new Bank { Name="Stanbic Bank Botswana Limited",PayeeClassID=2,Payable=false },
                   new Bank { Name="Standard Chartered Bank Botswana Limited",PayeeClassID=2,Payable=false },
                   new Bank { Name="State Bank of India (Botswana) Limited",PayeeClassID=2,Payable=false }
                };

                foreach (Bank b in banks)
                {
                    context.Banks.Add(b);
                }
                context.SaveChanges();

                var bankbranches = new BankBranch[]
                {
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Palapye",BIC="065067",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Tsabong",BIC="292167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Lobatse",BIC="281767",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Game City ",BIC="293567",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Palapye",BIC="283167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Maun",BIC="661967",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Broadhurst",BIC="281267",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Private Clients",BIC="283767",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Head Office",BIC="060467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Barclays House",BIC="290267",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Serowe Mahalapye Palapye",BIC="291467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Carbo centre",BIC="290767",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Selibe Phikwe",BIC="285067",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Kasane",BIC="292067",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Main Branch",BIC="281467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Corporate",BIC="282267",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Treasury",BIC="282167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Bofex",BIC="290667",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Ramotswa ",BIC="292767",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Gaborone Industrial",BIC="662367",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Gaborone Industrial",BIC="290367",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Gaborone Sun Prestige",BIC="293467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Kanye",BIC="281967",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Mogoditshane ",BIC="292967",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="CBD",BIC="065167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Airport Junction",BIC="662567",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Francistown",BIC="281867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Broadhurst",BIC="060367",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Blue Jacket",BIC="064867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Game City",BIC="662867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Francistown",BIC="661767",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Jwaneng",BIC="283067",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Industrial",BIC="061967",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Letlhakane",BIC="285567",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Mahalapye",BIC="282467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="customer Service",BIC="660167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Francistown",BIC="291767",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Gaborone Mall",BIC="282867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Orapa",BIC="290967",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Gaborone Mall",BIC="290167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Head Office",BIC="297867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Molepolole ",BIC="065467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Selebi Phikwe",BIC="661667",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Game City ",BIC="284567",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Jwaneng",BIC="660967",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Gaborone West",BIC="060167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Maun",BIC="064767",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Prestige Mall",BIC="294467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Selebi Phikwe",BIC="291667",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Lobatse",BIC="660867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Maun",BIC="282367",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Industrial",BIC="281667",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Orapa",BIC="661867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Moshupa",BIC="292867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Hemamo Centre",BIC="662767",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Wesbank",BIC="281567",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Phakalane ",BIC="290467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Molepolole",BIC="285667",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Airport Junction",BIC="288267",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Jwaneng ",BIC="291067",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Francistown",BIC="064067",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Bank of Baroda (Botswana) Limited").ID,Name="Francistown",BIC="11016",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Head Office",BIC="282067",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Palapye",BIC="661567",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Stannic",BIC="060567",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Ghantsi",BIC="291167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Gaborone Savings",BIC="296467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Serowe",BIC="285367",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Tlokweng",BIC="292667",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="Riverwalk Plaza",BIC="285267",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Broadhurst",BIC="662467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Maun",BIC="291967",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Gaborone Mall",BIC="662167",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Stanbic Bank Botswana Limited").ID,Name="Fairground",BIC="064967",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Standard House",BIC="662267",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Merafhe",BIC="290567",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "First National Bank of Botswana Limited").ID,Name="FNB Private clients",BIC="285467",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Barclays Bank of Botswana Limited").ID,Name="Lobatse",BIC="290867",SwiftCode=""},
                    new BankBranch {BankID=banks.Single(b => b.Name == "Standard Chartered Bank Botswana Limited").ID,Name="Mahalapye",BIC="661367",SwiftCode=""},
                };
                foreach (BankBranch b in bankbranches)
                {
                    context.BankBranches.Add(b);
                }
                context.SaveChanges();

                var components = new Component[]
                {
                   new Component { Name="Business All Risks"},
                   new Component { Name="Business Interruption"},
                   new Component { Name="Business Loan"},
                   new Component { Name="Business Property"},
                   new Component { Name="Commercial General Liability"},
                   new Component { Name="Credit Card Protection"},
                   new Component { Name="Errors and Omissions"},
                   new Component { Name="Fidelity"},
                   new Component { Name="Mortgage"},
                   new Component { Name="Personal Loan"},
                   new Component { Name="Plant and Machinery"},
                   new Component { Name="Workers' Compensation"}
                };
                foreach (Component c in components)
                {
                    context.Components.Add(c);
                }
                context.SaveChanges();

                var claimdocuments = new ClaimDocument[]
                {
                   new ClaimDocument { Name="Death Certificate",Mandatory=true},
                   new ClaimDocument { Name="Driver's License",Mandatory=true},
                   new ClaimDocument { Name="Police Report",Mandatory=true},
                   new ClaimDocument { Name="Quotation",Mandatory=true},
                   new ClaimDocument { Name="Registration Book",Mandatory=false}
                };
                foreach (ClaimDocument c in claimdocuments)
                {
                    context.ClaimDocuments.Add(c);
                }
                context.SaveChanges();

                var insurers = new Insurer[]
                {
                   new Insurer { Name="Botswana Insurance Company",PayeeClassID=2,Payable=false },
                   new Insurer { Name="Hollard Insurance Company",PayeeClassID=2,Payable=false },
                   new Insurer { Name="Old Mutual Insurance Company",PayeeClassID=2,Payable=false },
                   new Insurer { Name="Metropolitan Botswana",PayeeClassID=2,Payable=false },
                   new Insurer { Name="Botswana Life Insurance",PayeeClassID=2,Payable=false },
                   new Insurer { Name="Government Loan Insured Fund",PayeeClassID=2,Payable=false },
                   new Insurer { Name="Regent Insurance Company",PayeeClassID=2,Payable=false },
                   new Insurer { Name="Zurich Insurance Company",PayeeClassID=2,Payable=false }
                };
                foreach (Insurer d in insurers)
                {
                    context.Insurers.Add(d);
                }
                context.SaveChanges();

                var lossadjusters = new LossAdjuster[]
                {
                   new LossAdjuster { Name="Southern Sky Operations (Pty) Ltd",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Forensic Engineering Bureau",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Associated Loss Adjusters (Pty) Ltd",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Edwards Vehicle Claims Management (Pty) Ltd",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Alacrity (Pty) Ltd",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Loss Adjusters Botswana",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Professional Assessing Centre",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Uys Fritz & Associates",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Julesh Motor Vehicle Consultants",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Maxtrust Continental",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Keylink Loss Adjusters & Risk Management Consultants",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Accident Assessment & Auditors",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Lockdown Claims & Assessors",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="LDI (Pty) Ltd",PayeeClassID=5,Payable=false },
                   new LossAdjuster { Name="Claims Assessing Services",PayeeClassID=5,Payable=false }
                };
                foreach (LossAdjuster l in lossadjusters)
                {
                    context.LossAdjusters.Add(l);
                }
                context.SaveChanges();

                var occupations = new Occupation[]
                {
                   new Occupation { Name="Accountant"},
                   new Occupation { Name="Archaeologist"},
                   new Occupation { Name="Banker"},
                   new Occupation { Name="Barrister"},
                   new Occupation { Name="Broker"},
                   new Occupation { Name="Civil Servant"},
                   new Occupation { Name="Clinical Biochemist"},
                   new Occupation { Name="Counsellor"},
                   new Occupation { Name="Consultant"},
                   new Occupation { Name="Dentist"},
                   new Occupation { Name="Doctor"},
                   new Occupation { Name="Economist"},
                   new Occupation { Name="Engineer"},
                   new Occupation { Name="Executive Management"},
                   new Occupation { Name="Health Worker"},
                   new Occupation { Name="Information Technology"},
                   new Occupation { Name="Lawyer"},
                   new Occupation { Name="NotApplicable"},
                   new Occupation { Name="Nurse"},
                   new Occupation { Name="Pharmacist"},
                   new Occupation { Name="Politician"},
                   new Occupation { Name="Risk Professional"},
                   new Occupation { Name="Safety, Health and Environment"},
                   new Occupation { Name="Teacher"},
                   new Occupation { Name="Tradesman"},
                   new Occupation { Name="Underwriter"}
                };

                foreach (Occupation o in occupations)
                {
                    context.Occupations.Add(o);
                }
                context.SaveChanges();

                var attorneys = new Attorney[]
                {
                   new Attorney { Name="Uys Fritz and Associates",PayeeClassID=1,Payable=false },
                   new Attorney { Name="Osei-Ofei Swabi and Company",PayeeClassID=1,Payable=false },
                   new Attorney { Name="Braam Vanvuren and Associates",PayeeClassID=1,Payable=false },
                   new Attorney { Name="Kgalemang and Associates",PayeeClassID=1,Payable=false },
                   new Attorney { Name="Monthe Marumo and Company",PayeeClassID=1,Payable=false }
                };
                foreach (Attorney a in attorneys)
                {
                    context.Attorneys.Add(a);
                }
                context.SaveChanges();

                var tracingagents = new TracingAgent[]
                {
                   new TracingAgent { Name="Cartrack Botswana",PayeeClassID=8,Payable=false },
                   new TracingAgent { Name="CTrack Botswana",PayeeClassID=8,Payable=false },
                   new TracingAgent { Name="Netstar Botswana",PayeeClassID=8,Payable=false },
                   new TracingAgent { Name="Peekaboo Tracing Agency",PayeeClassID=8,Payable=false },
                   new TracingAgent { Name="Recoveri Botswana",PayeeClassID=8,Payable=false }
                };
                foreach (TracingAgent t in tracingagents)
                {
                    context.TracingAgents.Add(t);
                }
                context.SaveChanges();

                var claimstatuses = new ClaimStatus[]
                {
                   new ClaimStatus { Name="In Progress",Updatable=true},
                   new ClaimStatus { Name="Accepted",Updatable=false},
                   new ClaimStatus { Name="Cancelled",Updatable=false},
                   new ClaimStatus { Name="Denied",Updatable=false},
                   new ClaimStatus { Name="Reopened",Updatable=true}
                };
                foreach (ClaimStatus c in claimstatuses)
                {
                    context.ClaimStatuses.Add(c);
                }
                context.SaveChanges();

                var repairers = new Repairer[]
                {
                   new Repairer { Name="Ramvill Panel Beaters",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Car World (Pty) Ltd",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Auto Body Works (Pty) Ltd",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Mogoditshane Motors",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Z-Tune Body Works",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Specialised Auto Body Repairers (Pty) Ltd",PayeeClassID=6,Payable=false },
                   new Repairer { Name="PG Glass",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Blue Chip Panel Beaters (Pty) Ltd",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Manjeya Panel Beaters (Pty) Ltd",PayeeClassID=6,Payable=false },
                   new Repairer { Name="JJ Motors (Pty) Ltd",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Francistown Panel Beaters",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Auto Korea Services",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Automech Panel Beaters",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Emergency Steel & Panel Beaters",PayeeClassID=6,Payable=false },
                   new Repairer { Name="Mak-Kan Glass Fitment Centre",PayeeClassID=6,Payable=false }
                };
                foreach (Repairer r in repairers)
                {
                    context.Repairers.Add(r);
                }
                context.SaveChanges();

                var containers = new Container[]
                {
                   new Container { Name="Local Authorities Self Insured Fund",ContactPerson="Itumeleng Ntalagbwe",Business="Local Authorities",CountryID=countries.Single(b => b.Name == "Botswana").ID},
                   new Container { Name="Land Boards Self Insured Fund",ContactPerson="Itumeleng Ntalagbwe",Business="Land Boards",CountryID=countries.Single(b => b.Name == "Botswana").ID},
                   new Container { Name="Small, Medium and Micro-Sized Enterprises",ContactPerson="Itumeleng Ntalagbwe",Business="Entrepreneurs",CountryID=countries.Single(b => b.Name == "Botswana").ID},
                   new Container { Name="Bancassurance",ContactPerson="Peter Hikhwa",Business="Credit Life",CountryID=countries.Single(b => b.Name == "Botswana").ID},
                   new Container { Name="Government Loan Insured Fund",ContactPerson="Itumeleng Ntalagbwe",Business="Public Administration",CountryID=countries.Single(b => b.Name == "Botswana").ID},
                   new Container { Name="Non-Government Loan Insured Fund",ContactPerson="Itumeleng Ntalagbwe",Business="Public Administration",CountryID=countries.Single(b => b.Name == "Botswana").ID},
                   new Container { Name="Affinity",ContactPerson="Itumeleng Ntalabgwe",Business="Various",CountryID=countries.Single(b => b.Name == "Botswana").ID},
                   new Container { Name="Personal Lines Division",ContactPerson="Itumeleng Ntalagbwe",Business="Individuals",CountryID=countries.Single(b => b.Name == "Botswana").ID},
                   new Container { Name="University of Botswana",ContactPerson="Itumeleng Ntalagbwe",Business="Individuals",CountryID=countries.Single(b => b.Name == "Botswana").ID}
                };
                foreach (Container c in containers)
                {
                    context.Containers.Add(c);
                }
                context.SaveChanges();

                var products = new Product[]
                {
                   new Product { ContainerID=containers.Single(b => b.Name == "Local Authorities Self Insured Fund").ID, Name="Gaborone City Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Land Boards Self Insured Fund").ID, Name="Kgatleng Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Small, Medium and Micro-Sized Enterprises").ID, Name="Commercial Covers",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Standard Chartered Bank Individual Loans",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="BancABC Individual Loans",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Broadhurst",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Mall",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Selebi Phikwe",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Industrial",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Maun",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Francistown",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Lobatse",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Serowe",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - BDF",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Bancassurance").ID, Name="Barclays Bank Individual Loans - Orapa",RenewalPeriod=0},
                   new Product { ContainerID=containers.Single(b => b.Name == "Government Loan Insured Fund").ID, Name="Government Employees Motor",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Government Loan Insured Fund").ID, Name="Government Employees Property",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Bobirwa Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Boteti Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Botswana Postal Service",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Botswana Railways",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Botswana Unified Revenue Service",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Central District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Charles Hill Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Chobe Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Chobe Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Francistown City Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Gaborone City Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Ghanzi District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Ghanzi Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Good Hope Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Hukuntsi Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Jwaneng Town Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Kanye Administration Authority",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Kgalagadi District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Kgalagadi Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Kgatleng District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Kgatleng Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Kweneng District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Kweneng Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Letlhakane Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Lobatse Town Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Mabutsane Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Mahalapye Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Malete Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Maun Administrative Authority",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Mogoditshane Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Moshupa Sub District",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Ngwaketse Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Ngwato Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="North East District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="North West District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Okavango Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Rolong Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Selebi Phikwe Town Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Serowe Administration Authority",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Serowe-Palapye Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="South East District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Southern District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Sowa Township Authority",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Tati Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Tawana Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Tlokweng Land Board",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Tlokweng Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Tonota Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Tsabong Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Non-Government Loan Insured Fund").ID, Name="Tutume Sub District Council",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Affinity").ID, Name="Structured Portfolio Products",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "University of Botswana").ID, Name="Staff Loan",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "University of Botswana").ID, Name="Extended Loan",RenewalPeriod=3},
                   new Product { ContainerID=containers.Single(b => b.Name == "Personal Lines Division").ID, Name="Pula Cover",RenewalPeriod=3}
                };
                foreach (Product p in products)
                {
                    context.Products.Add(p);
                }
                context.SaveChanges();

                var drivertypes = new DriverType[]
                {
                   new DriverType { Name="Any Insured Driver"},
                   new DriverType { Name="Insured and any Family Member"},
                   new DriverType { Name="Insured Only"}
                };
                foreach (DriverType d in drivertypes)
                {
                    context.DriverTypes.Add(d);
                }
                context.SaveChanges();

                var motortypes = new MotorType[]
                {
                   new MotorType { Name="Convertible"},
                   new MotorType { Name="Coupe"},
                   new MotorType { Name="Crossover"},
                   new MotorType { Name="Electric"},
                   new MotorType { Name="Hatchback"},
                   new MotorType { Name="Hybrid"},
                   new MotorType { Name="PickUp Truck"},
                   new MotorType { Name="Sedan"},
                   new MotorType { Name="Sport"},
                   new MotorType { Name="SUV"},
                   new MotorType { Name="Van"},
                   new MotorType { Name="Wagon"}
                };
                foreach (MotorType m in motortypes)
                {
                    context.MotorTypes.Add(m);
                }
                context.SaveChanges();

                var motormakes = new MotorMake[]
                {
                    new MotorMake { Name="Acura"},
                    new MotorMake { Name="Aston Martin"},
                    new MotorMake { Name="Audi"},
                    new MotorMake { Name="BMW"},
                    new MotorMake { Name="Buick"},
                    new MotorMake { Name="Cadillac"},
                    new MotorMake { Name="Chevrolet"},
                    new MotorMake { Name="Chrysler"},
                    new MotorMake { Name="Dodge"},
                    new MotorMake { Name="Ferarri"},
                    new MotorMake { Name="Ford"},
                    new MotorMake { Name="GMC"},
                    new MotorMake { Name="Honda"},
                    new MotorMake { Name="Hummer"},
                    new MotorMake { Name="Hyundai"},
                    new MotorMake { Name="Infiniti"},
                    new MotorMake { Name="Isuzu"},
                    new MotorMake { Name="Jaguar"},
                    new MotorMake { Name="Jeep"},
                    new MotorMake { Name="Kia"},
                    new MotorMake { Name="Land Rover"},
                    new MotorMake { Name="Lexus"},
                    new MotorMake { Name="Lincoln"},
                    new MotorMake { Name="Lotus"},
                    new MotorMake { Name="Maserati"},
                    new MotorMake { Name="Mazda"},
                    new MotorMake { Name="Mercedes-Benz"},
                    new MotorMake { Name="Mercury"},
                    new MotorMake { Name="MINI"},
                    new MotorMake { Name="Mitsubishi"},
                    new MotorMake { Name="Nissan"},
                    new MotorMake { Name="Pontaic"},
                    new MotorMake { Name="Porsche"},
                    new MotorMake { Name="Rolls-Royce"},
                    new MotorMake { Name="Saab"},
                    new MotorMake { Name="Saturn"},
                    new MotorMake { Name="Scion"},
                    new MotorMake { Name="Smart"},
                    new MotorMake { Name="Subaru"},
                    new MotorMake { Name="Suzuki"},
                    new MotorMake { Name="Toyota"},
                    new MotorMake { Name="Volkswagon"},
                    new MotorMake { Name="Volvo"}
                };
                foreach (MotorMake m in motormakes)
                {
                    context.MotorMakes.Add(m);
                }
                context.SaveChanges();

                var motormodels = new MotorModel[]
                {
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Acura").ID,Name="MDX"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Acura").ID,Name="RDX"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Acura").ID,Name="RL"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Acura").ID,Name="TL"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Acura").ID,Name="TSX"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Aston Martin").ID,Name="DB9"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="A3"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="A4"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="A5"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="A6"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="A8"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="Q7"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="R8"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="RS 4"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="S4"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="S5"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="S6"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="S8"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Audi").ID,Name="TT"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="128"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="135"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="328"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="335"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="528"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="535"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="550"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="650"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="750"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="760"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="Alpina B7"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="M3"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="M5"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="M6"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="X3"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="X5"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="X6"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="Z4"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="BMW").ID,Name="Z4 M"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Buick").ID,Name="Enclave"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Buick").ID,Name="LaCrosse"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Buick").ID,Name="Lucerne"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Cadillac").ID,Name="CTS"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Cadillac").ID,Name="DTS"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Cadillac").ID,Name="Escalade"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Cadillac").ID,Name="Escalade ESV"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Cadillac").ID,Name="Escalade EXT"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Cadillac").ID,Name="SRX"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Cadillac").ID,Name="STS"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Cadillac").ID,Name="XLR"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Avalanche"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Aveo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Cobalt"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Colorado Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Colorado Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Colorado Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Corvette"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Equinox"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Express 1500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Express 1500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Express 2500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Express 2500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Express 3500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Express 3500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="HHR"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Impala"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Malibu"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Malibu (Classic)"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 1500 Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 1500 Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 1500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 2500 HD Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 2500 HD Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 2500 HD Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 3500 HD Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 3500 HD Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Silverado 3500 HD Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Suburban 1500"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Suburban 2500"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Tahoe"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="TrailBlazer"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Traverse"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Uplander Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chevrolet").ID,Name="Uplander Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chrysler").ID,Name="10 68|300"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chrysler").ID,Name="Crossfire"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chrysler").ID,Name="Pacifica"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chrysler").ID,Name="PT Cruiser"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chrysler").ID,Name="Sebring"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chrysler").ID,Name="spen"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Chrysler").ID,Name="Town & Country"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Avenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Caliber"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Caravan Grand Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Caravan Grand Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Challenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Charger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Dakota Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Dakota Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Durango"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Journey"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Magnum"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Nitro"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 1500 Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 1500 Mega Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 1500 Quad Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 1500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 2500 Mega Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 2500 Quad Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 2500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 3500 Mega Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 3500 Quad Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Ram 3500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Sprinter 2500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Sprinter 2500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Sprinter 3500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Dodge").ID,Name="Viper"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ferarri").ID,Name="430 Scuderia"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ferarri").ID,Name="599 GTB Fiorano"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ferarri").ID,Name="612 Scaglietti"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ferarri").ID,Name="F430"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="E150 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="E150 Super Duty Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="E250 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="E350 Super Duty Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="E350 Super Duty Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Edge"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Escape"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Expedition"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Expedition EL"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Explorer"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Explorer Sport Trac"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F150 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F150 Super Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F150 SuperCrew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F250 Super Duty Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F250 Super Duty Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F250 Super Duty Super Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F350 Super Duty Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F350 Super Duty Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F350 Super Duty Super Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="F450 Super Duty Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Flex"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Focus"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Fusion"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Mustang"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Ranger Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Ranger Super Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Taurus"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Ford").ID,Name="Taurus X"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Acadia"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Canyon Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Canyon Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Canyon Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Envoy"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Savana 1500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Savana 1500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Savana 2500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Savana 2500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Savana 3500 Cargo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Savana 3500 Passenger"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 1500 Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 1500 Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 1500 Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 2500 HD Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 2500 HD Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 2500 HD Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 3500 HD Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 3500 HD Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Sierra 3500 HD Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Yukon"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Yukon XL 1500"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="GMC").ID,Name="Yukon XL 2500"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="Accord"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="Civic"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="CR-V"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="Element"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="Fit"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="Odyssey"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="Pilot"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="Ridgeline"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Honda").ID,Name="S2000"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hummer").ID,Name="H2"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hummer").ID,Name="H3"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Accent"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Azera"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Elantra"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Entourage"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Genesis"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Santa Fe"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Sonata"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Tiburon"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Tucson"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Hyundai").ID,Name="Veracruz"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="EX35"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="FX35"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="FX45"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="FX50"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="G35"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="G37"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="M35"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="M45"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Infiniti").ID,Name="QX56"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Isuzu").ID,Name="Ascender"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Isuzu").ID,Name="i-290 Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Isuzu").ID,Name="i-370 Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Isuzu").ID,Name="i-370 Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jaguar").ID,Name="S-Type"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jaguar").ID,Name="XF"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jaguar").ID,Name="XJ Series"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jaguar").ID,Name="XK Series"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jaguar").ID,Name="X-Type"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jeep").ID,Name="Commander"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jeep").ID,Name="Compass"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jeep").ID,Name="Grand Cherokee"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jeep").ID,Name="Liberty"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jeep").ID,Name="Patriot"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Jeep").ID,Name="Wrangler"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Amanti"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Borrego"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Optima"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Rio"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Rondo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Sedona"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Sorento"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Spectra"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Kia").ID,Name="Sportage"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Land Rover").ID,Name="LR2"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Land Rover").ID,Name="LR3"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Land Rover").ID,Name="Range Rover"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Land Rover").ID,Name="Range Rover Sport"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="ES 350"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="GS 350"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="GS 450h"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="GS 460"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="GX 470"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="IS 250"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="IS 350"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="IS F"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="LS 460"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="LS 600h"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="LX 570"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="RX 350"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="RX 400h"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lexus").ID,Name="SC 430"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lincoln").ID,Name="Mark LT"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lincoln").ID,Name="MKS"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lincoln").ID,Name="MKX"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lincoln").ID,Name="MKZ"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lincoln").ID,Name="Navigator"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lincoln").ID,Name="Navigator L"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lincoln").ID,Name="Town Car"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lotus").ID,Name="Elise"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Lotus").ID,Name="Exige S"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Maserati").ID,Name="GranTurismo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Maserati").ID,Name="Quattroporte"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="B-Series Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="B-Series Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="CX-7"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="CX-9"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="MAZDA3"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="MAZDA5"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="MAZDA6"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="Miata MX-5"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="RX-8"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mazda").ID,Name="Tribute"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="C-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="CL-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="CLK-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="CLS-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="E-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="G-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="GL-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="ML-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="R-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="S-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="SL-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="SLK-Class"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercedes-Benz").ID,Name="SLR McLaren"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercury").ID,Name="Grand Marquis"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercury").ID,Name="Mariner"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercury").ID,Name="Milan"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercury").ID,Name="Mountaineer"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mercury").ID,Name="Sable"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="MINI").ID,Name="Cooper"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mitsubishi").ID,Name="Eclipse"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mitsubishi").ID,Name="Endeavor"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mitsubishi").ID,Name="Galant"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mitsubishi").ID,Name="Lancer"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mitsubishi").ID,Name="Outlander"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mitsubishi").ID,Name="Raider Double Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Mitsubishi").ID,Name="Raider Extended Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="350Z"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Altima"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Armada"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Frontier Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Frontier King Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="GT-R"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Maxima"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Murano"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Pathfinder"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Quest"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Rogue"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Sentra"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Titan Crew Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Titan King Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Versa"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Nissan").ID,Name="Xterra"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Pontaic").ID,Name="G5"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Pontaic").ID,Name="G6"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Pontaic").ID,Name="G8"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Pontaic").ID,Name="Grand Prix"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Pontaic").ID,Name="Solstice"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Pontaic").ID,Name="Torrent"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Pontaic").ID,Name="Vibe"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Porsche").ID,Name="911"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Porsche").ID,Name="Boxster"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Porsche").ID,Name="Cayenne"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Porsche").ID,Name="Cayman"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Rolls-Royce").ID,Name="Phantom"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Saab").ID,Name="9-7X"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Saturn").ID,Name="Astra"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Saturn").ID,Name="Aura"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Saturn").ID,Name="Outlook"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Saturn").ID,Name="SKY"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Saturn").ID,Name="VUE"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Scion").ID,Name="tC"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Scion").ID,Name="xB"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Scion").ID,Name="xD"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Smart").ID,Name="fortwo"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Subaru").ID,Name="Forester"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Subaru").ID,Name="Impreza"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Subaru").ID,Name="Legacy"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Subaru").ID,Name="Outback"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Subaru").ID,Name="Tribeca"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Suzuki").ID,Name="Forenza"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Suzuki").ID,Name="Grand Vitara"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Suzuki").ID,Name="Reno"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Suzuki").ID,Name="SX4"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Suzuki").ID,Name="XL7"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="4Runner"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Avalon"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Camry"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Corolla"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="FJ Cruiser"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Highlander"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Land Cruiser"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Matrix"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Prius"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="RAV4"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Sequoia"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Sienna"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Solara"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Tacoma Access Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Tacoma Double Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Tacoma Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Tundra CrewMax"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Tundra Double Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Tundra Regular Cab"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Toyota").ID,Name="Yaris"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="CC"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="Eos"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="GLI"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="GTI"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="Jetta"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="New Beetle"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="Passat"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="R32"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="Rabbit"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="Routan"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="Tiguan"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="Touareg"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volkswagon").ID,Name="Touareg 2"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="C30"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="C70"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="S40"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="S60"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="S80"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="V50"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="V70"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="XC70"},
                    new MotorModel { MotorMakeID=motormakes.Single(m => m.Name =="Volvo").ID,Name="XC90"}
                };
                foreach (MotorModel m in motormodels)
                {
                    context.MotorModels.Add(m);
                }
                context.SaveChanges();

                var residencetypes = new ResidenceType[]
                {
                   new ResidenceType { Name="Owner"},
                   new ResidenceType { Name="Tenant"}
                };
                foreach (ResidenceType d in residencetypes)
                {
                    context.ResidenceTypes.Add(d);
                }
                context.SaveChanges();

                var rooftypes = new RoofType[]
                {
                   new RoofType { Name="Asphalt"},
                   new RoofType { Name="Metal"},
                   new RoofType { Name="Thatch"},
                   new RoofType { Name="Bitumen"},
                   new RoofType { Name="Wood"}
                };
                foreach (RoofType d in rooftypes)
                {
                    context.RoofTypes.Add(d);
                }
                context.SaveChanges();

                var walltypes = new WallType[]
                {
                   new WallType { Name="Brick and Mortar"},
                   new WallType { Name="Metal"},
                   new WallType { Name="Prefabricated"},
                   new WallType { Name="Wood"}
                };
                foreach (WallType d in walltypes)
                {
                    context.WallTypes.Add(d);
                }
                context.SaveChanges();

                var coverages = new Coverage[]
                {
                   new Coverage { Name="Additional Living Expense"},
                   new Coverage { Name="Third Party Fire and Theft"},
                   new Coverage { Name="Damage to Property"},
                   new Coverage { Name="Other Structures"},
                   new Coverage { Name="Comprehensive Personal Liability"},
                   new Coverage { Name="Comprehensive"},
                   new Coverage { Name="Third Party Only"},
                   new Coverage { Name="Personal Property"},
                   new Coverage { Name="Medical Expense"}
                };
                foreach (Coverage d in coverages)
                {
                    context.Coverages.Add(d);
                }
                context.SaveChanges();

                var policystatuses = new PolicyStatus[]
                {
                   new PolicyStatus { Name="Open", Updatable=true},
                   new PolicyStatus { Name="Closed", Updatable=false},
                   new PolicyStatus { Name="Lapsed", Updatable=false}
                };
                foreach (PolicyStatus c in policystatuses)
                {
                    context.PolicyStatuses.Add(c);
                }
                context.SaveChanges();

                var policyfrequencies = new PolicyFrequency[]
                {
                   new PolicyFrequency { Name="Annual", Divisor=1},
                   new PolicyFrequency { Name="Monthly", Divisor=12},
                   new PolicyFrequency { Name="Quarterly", Divisor=4},
                   new PolicyFrequency { Name="Perpetual", Divisor=1}
                };
                foreach (PolicyFrequency c in policyfrequencies)
                {
                    context.PolicyFrequencies.Add(c);
                }
                context.SaveChanges();

                var paymenttypes = new PaymentType[]
                {
                   new PaymentType { ID=1,Name="Cash"},
                   new PaymentType { ID=2,Name="EFT"},
                   new PaymentType { ID=3,Name="Cheque"},
                   new PaymentType { ID=4,Name="Direct Debit"},
                   new PaymentType { ID=5,Name="Bank Transfer"}
                };
                foreach (PaymentType d in paymenttypes)
                {
                    context.PaymentTypes.Add(d);
                }
                context.SaveChanges();

                var premiumtypes = new PremiumType[]
                {
                    new PremiumType { Name="Payment"},
                    new PremiumType { Name="Adjustment"}
                };
                foreach (PremiumType d in premiumtypes)
                {
                    context.PremiumTypes.Add(d);
                }
                context.SaveChanges();

                var transactiontypes = new TransactionType[]
                {
                   new TransactionType { Name="Reversal"},
                   new TransactionType { Name="Settlement"}
                };
                foreach (TransactionType d in transactiontypes)
                {
                    context.TransactionTypes.Add(d);
                }
                context.SaveChanges();

                var payeeclasses = new PayeeClass[]
                {
                   new PayeeClass { ID=1,Name="Attorney"},
                   new PayeeClass { ID=2,Name="Bank"},
                   new PayeeClass { ID=3,Name="Insured"},
                   new PayeeClass { ID=4,Name="Insurer"},
                   new PayeeClass { ID=5,Name="Loss Adjuster"},
                   new PayeeClass { ID=6,Name="Repairer"},
                   new PayeeClass { ID=7,Name="Third Party"},
                   new PayeeClass { ID=8,Name="Tracing Agent"}
                };
                foreach (PayeeClass p in payeeclasses)
                {
                    context.PayeeClasses.Add(p);
                }
                context.SaveChanges();

                var risks = new Risk[]
                {
                   new Risk { ID=1,Name="AllRisk",Description="Provides coverages for any incident that " +
                        "an insurance policy doesn't specifically exclude."},
                   new Risk { ID=2,Name="Commercial",Description="Provides coverage to a business for " +
                       "injury and property damage that occurs on the business premises."},
                   new Risk { ID=3,Name="Content",Description="Provides for cover for damage to, or loss " +
                        "of, an individual's personal possessions while they are located within that individual's home."},
                   new Risk { ID=4,Name="Loan",Description="Provides covers for personal loan debt in " +
                        "the event of death, disability or dread disease."},
                   new Risk { ID=5,Name="Motor",Description="Provides cover for a motor vehicle such as " +
                        "a car, which provides protection against loss in the event of an accident, theft, etc"},
                   new Risk { ID=6,Name="Property",Description="Provides protection against most risks to " +
                        "property, such as fire, theft and some weather damage."},
                   new Risk { ID=7,Name="Workman",Description="Provides compensation to employees " +
                        "injured in the course of employment."}
                };
                foreach (Risk d in risks)
                {
                    context.Risks.Add(d);
                }
                context.SaveChanges();

                var productrisks = new ProductRisk[]
                {
                   new ProductRisk { ProductID=products.Single(m => m.Name =="Government Employees Motor").ID,
                       RiskID =risks.Single(m => m.Name =="Motor").ID, ClaimLimit=150000, ClaimPrefix=64,
                       UseCFG =true, PolicyFee=10, Commission=decimal.Parse("12.5")},
                   new ProductRisk { ProductID=products.Single(m => m.Name =="Government Employees Property").ID,
                       RiskID =risks.Single(m => m.Name =="Property").ID, ClaimLimit=1500000, ClaimPrefix=63,
                       UseCFG =true, PolicyFee=10, Commission=decimal.Parse("20")},
                   new ProductRisk { ProductID=products.Single(m => m.Name =="Pula Cover").ID,
                       RiskID =risks.Single(m => m.Name =="Motor").ID, ClaimLimit=150000, ClaimPrefix=42,
                       UseCFG =true, PolicyFee=10, Commission=decimal.Parse("12.5")}
                };
                foreach (ProductRisk p in productrisks)
                {
                    context.ProductRisks.Add(p);
                }
                context.SaveChanges();

                var titles = new Title[]
                {
                   new Title { Name="Advocate"},
                   new Title { Name="Dr"},
                   new Title { Name="Kgosi"},
                   new Title { Name="Honourable"},
                   new Title { Name="Justice"},
                   new Title { Name="Messrs"},
                   new Title { Name="Miss"},
                   new Title { Name="Mr"},
                   new Title { Name="Mrs"},
                   new Title { Name="Ms"},
                   new Title { Name="NotApplicable"},
                   new Title { Name="Prof"},
                   new Title { Name="Reverend"},
                   new Title { Name="General"}
                };
                foreach (Title t in titles)
                {
                    context.Titles.Add(t);
                }
                context.SaveChanges();

                var thirdparties = new ThirdParty[]
                {
                    new ThirdParty { FirstName="Thari Mothusi",LastName="Madisa",IDNumber="962017907",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Kealeboga Lebo",LastName="Chibane",IDNumber="979920912",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Molefe",LastName="Morapedi",IDNumber="524113801",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Hildah",LastName="Kekailwe",IDNumber="050223403",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Masilo",LastName="Kegakgametse",IDNumber="129812913",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Usina",LastName="Basimako",IDNumber="424629205",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Modise",LastName="Phokoje",IDNumber="378815300",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Marks Bangi",LastName="Tshebo",IDNumber="861517405",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Gosego",LastName="Zemona",IDNumber="670324107",PayeeClassID=7,Payable=false },
                    new ThirdParty { FirstName="Shylot Oteng",LastName="Nombolo",IDNumber="483717310",PayeeClassID=7,Payable=false }
                };
                foreach (ThirdParty c in thirdparties)
                {
                    context.ThirdParties.Add(c);
                }
                context.SaveChanges();

                var clienttypes = new ClientType[]
                {
                   new ClientType { Name="Company",IsFirm=true},
                   new ClientType { Name="Business Name",IsFirm=true},
                   new ClientType { Name="Individual",IsFirm=false}
                };
                foreach (ClientType c in clienttypes)
                {
                    context.ClientTypes.Add(c);
                }
                context.SaveChanges();

                var claimclasses = new ClaimClass[]
                {
                   new ClaimClass { Name="Auto"},
                   new ClaimClass { Name="Business/Other"},
                   new ClaimClass { Name="Life/Retirement"},
                   new ClaimClass { Name="Power Sports"},
                   new ClaimClass { Name="Property"}
                };
                foreach (ClaimClass c in claimclasses)
                {
                    context.ClaimClasses.Add(c);
                }
                context.SaveChanges();

                var incomeclasses = new IncomeClass[]
                {
                   new IncomeClass { Name="New Recurring Additional (RNE)" },
                   new IncomeClass { Name="Renewal Recurring Existing (RRE)" },
                   new IncomeClass { Name="New-New Recurring (RNN)" },
                   new IncomeClass { Name="New-Existing Recurring (NER)" },
                   new IncomeClass { Name="Non-Recurring Existing (NNE)" },
                   new IncomeClass { Name="New-New Non-Recurring (NNN)" },
                   new IncomeClass { Name="New-Existing Non-Recurring (NEN)"},
                   new IncomeClass { Name="Brokerage Fees Recurring Existing Client (FRE)" },
                   new IncomeClass { Name="Brokerage Fees Recurring Additional (FNB)" },
                   new IncomeClass { Name="Brokerage Fees Recurring New Client (FNN)" },
                   new IncomeClass { Name="Brokerage Fees Non-Recurring New Client (FPE)"},
                   new IncomeClass { Name="Brokerage Fees Non-Recurring Existing Client (FNP)" }
                };

                foreach (IncomeClass i in incomeclasses)
                {
                    context.IncomeClasses.Add(i);
                }
                context.SaveChanges();

                var incidents = new Incident[]
                {
                   new Incident { Name="Absconsion"},
                   new Incident { Name="Broken Window Glass"},
                   new Incident { Name="Death"},
                   new Incident { Name="Disability"},
                   new Incident { Name="Early Settlement"},
                   new Incident { Name="Fire"},
                   new Incident { Name="Flood"},
                   new Incident { Name="Hail Storm"},
                   new Incident { Name="Hit and Run"},
                   new Incident { Name="Hit Animal"},
                   new Incident { Name="Hit by Third Party"},
                   new Incident { Name="Hit Third Party"},
                   new Incident { Name="Loss of Keys"},
                   new Incident { Name="Radio Stolen"},
                   new Incident { Name="Refund"},
                   new Incident { Name="Riot"},
                   new Incident { Name="Single Vehicle"},
                   new Incident { Name="Vehicle Stolen"}
                };
                foreach (Incident i in incidents)
                {
                    context.Incidents.Add(i);
                }
                context.SaveChanges();

                var regions = new Region[]
                {
                   new Region { Name="Francistown",Description="National"},
                   new Region { Name="Gaborone",Description="National"},
                   new Region { Name="Good Hope",Description="National"},
                   new Region { Name="Jwaneng",Description="National"},
                   new Region { Name="Kanye",Description="National"},
                   new Region { Name="Kasane",Description="National"},
                   new Region { Name="Kazungula",Description="National"},
                   new Region { Name="Lesotho",Description="International"},
                   new Region { Name="Lobatse",Description="National"},
                   new Region { Name="Mahalapye",Description="National"},
                   new Region { Name="Maun",Description="National"},
                   new Region { Name="Mochudi",Description="National"},
                   new Region { Name="Mogodisthane",Description="National"},
                   new Region { Name="Molepolole",Description="National"},
                   new Region { Name="Moshupa",Description="National"},
                   new Region { Name="Mozambique",Description="International"},
                   new Region { Name="Namibia",Description="International"},
                   new Region { Name="Nata",Description="National"},
                   new Region { Name="Orapa",Description="National"},
                   new Region { Name="Other",Description="National"},
                   new Region { Name="Palapye",Description="National"},
                   new Region { Name="Ramotswa",Description="National"},
                   new Region { Name="Rural Other",Description="National"},
                   new Region { Name="Selebi Phikwe",Description="National"},
                   new Region { Name="South Africa",Description="International"},
                   new Region { Name="Swaziland",Description="International"},
                   new Region { Name="Thamaga",Description="National"},
                   new Region { Name="Zambia",Description="International"},
                   new Region { Name="Zimbabwe",Description="International"}
                };
                foreach (Region r in regions)
                {
                    context.Regions.Add(r);
                }
                context.SaveChanges();

                var affecteds = new Affected[]
                {
                   new Affected { Name="Bank"},
                   new Affected { Name="Insured"},
                   new Affected { Name="Insurer"},
                   new Affected { Name="Third Party"}
                };
                foreach (Affected a in affecteds)
                {
                    context.Affecteds.Add(a);
                }
                context.SaveChanges();

                var clients = new Client[]
                {
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Island",LastName="Molobe",BirthDate=DateTime.ParseExact("12/04/1968","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="718614601",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Civil Servant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Khumoetsile",LastName="Letsweletse",BirthDate=DateTime.ParseExact("25/12/1968","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="214412205",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Engineer").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Rosemary",LastName="Rammei",BirthDate=DateTime.ParseExact("02/01/1972","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="108221609",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Teacher").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Reuben",LastName="Erastus",BirthDate=DateTime.ParseExact("30/06/1953","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="848515605",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Health Worker").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mrs").ID,
                            FirstName="Thatafatso",LastName="Moagi",BirthDate=DateTime.ParseExact("31/08/1964","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="412323204",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Civil Servant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Cecilia",LastName="Bolaane",BirthDate=DateTime.ParseExact("11/11/1966","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="808020004",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Health Worker").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Nakedi",LastName="Morwagabusi",BirthDate=DateTime.ParseExact("07/04/1975","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="723512304",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Engineer").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mrs").ID,
                            FirstName="Moikgotlho",LastName="Nyatseng",BirthDate=DateTime.ParseExact("10/11/1954","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="605924402",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Teacher").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Mmusi",LastName="Mmusi",BirthDate=DateTime.ParseExact("05/05/1960","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="803011804",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Civil Servant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                   new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Miss").ID,
                            FirstName="Agness",LastName="Marope",BirthDate=DateTime.ParseExact("04/12/1956","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="718924001",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Civil Servant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mrs").ID,
                            FirstName="Kelebogile",LastName="Lekorwe",BirthDate=DateTime.ParseExact("21/01/1974","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="553229102",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Accountant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="France",LastName="Otlogile",BirthDate=DateTime.ParseExact("23/10/1973","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="677112908",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Economist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Buki Kwapa",LastName="Molebatsi",BirthDate=DateTime.ParseExact("26/03/1964","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="450614204",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Pharmacist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Thebeitsele",LastName="Rasebona",BirthDate=DateTime.ParseExact("23/11/1983","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="517912419",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Safety, Health and Environment").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Peter Kebadire",LastName="Sengalo",BirthDate=DateTime.ParseExact("09/09/1972","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="17315301",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Tradesman").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Keakabetse",LastName="Rabana",BirthDate=DateTime.ParseExact("06/04/1961","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="406821800",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Tradesman").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Shimane Don",LastName="Shine",BirthDate=DateTime.ParseExact("04/07/1975","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="589415804",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Tradesman").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Tebogo",LastName="Mokobeng",BirthDate=DateTime.ParseExact("07/10/1982","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="999526702",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Tradesman").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Sithokozile",LastName="Dube",BirthDate=DateTime.ParseExact("18/08/1979","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="808828910",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Nurse").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Palai Kenosi",LastName="Modise",BirthDate=DateTime.ParseExact("15/12/1969","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="46713209",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Clinical Biochemist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Muyapo Eric",LastName="Nthoiwa",BirthDate=DateTime.ParseExact("25/02/1981","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="19715012",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Counsellor").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Keamogetse",LastName="Keosekile",BirthDate=DateTime.ParseExact("13/08/1979","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="690414203",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Underwriter").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mrs").ID,
                            FirstName="Esther",LastName="Masala",BirthDate=DateTime.ParseExact("03/03/1979","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="89626804",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Teacher").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Unabo",LastName="Maposa",BirthDate=DateTime.ParseExact("27/09/1971","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="719718003",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Dentist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Odirile Ocean",LastName="Johannes",BirthDate=DateTime.ParseExact("03/10/1977","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="180910806",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Engineer").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Gontso",LastName="Ngorogwe",BirthDate=DateTime.ParseExact("01/01/1971","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="444117209",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Risk Professional").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Miss").ID,
                            FirstName="Michelle Angela",LastName="Kupa",BirthDate=DateTime.ParseExact("03/03/1973","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="758421704",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Barrister").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Joseph Albert",LastName="Pharudi",BirthDate=DateTime.ParseExact("01/01/1976","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="373319601",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Barrister").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Wabigwa",LastName="Mabuku",BirthDate=DateTime.ParseExact("15/02/1982","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="992215703",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Lawyer").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Mbuluki",LastName="Mooketsi",BirthDate=DateTime.ParseExact("31/03/1986","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="231310815",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Accountant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Solomon Masiku",LastName="Ipontsheng",BirthDate=DateTime.ParseExact("20/05/1993","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="624919818",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Politician").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Mahumapelo",LastName="Kelapile",BirthDate=DateTime.ParseExact("22/07/1988","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="376521811",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Health Worker").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Milo Mosupi",LastName="Baaisi",BirthDate=DateTime.ParseExact("20/06/1975","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="760617609",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Teacher").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Phillip Bathusanyi",LastName="Motau",BirthDate=DateTime.ParseExact("01/07/1969","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="537918009",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Civil Servant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Shima",LastName="Ntheetsang",BirthDate=DateTime.ParseExact("19/11/1970","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="845016605",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Politician").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Selinah",LastName="Gabaikgopole",BirthDate=DateTime.ParseExact("01/01/1972","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="256026308",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Accountant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mrs").ID,
                            FirstName="Keitumetse Alina",LastName="Monggae",BirthDate=DateTime.ParseExact("21/05/1958","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="348727203",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Teacher").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Kabo",LastName="Mongati",BirthDate=DateTime.ParseExact("13/06/1984","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="11810819",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Underwriter").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Tuelo",LastName="Ramogabane",BirthDate=DateTime.ParseExact("01/01/1983","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="811813612",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Pharmacist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mrs").ID,
                            FirstName="Keolebogile",LastName="Matlhonyane",BirthDate=DateTime.ParseExact("06/09/1987","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="475620810",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Nurse").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Lindani",LastName="Kenabatho",BirthDate=DateTime.ParseExact("21/08/1980","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="593326803",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Economist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Kgalalelo Wamasole",LastName="Mgumba",BirthDate=DateTime.ParseExact("15/10/1981","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="598628903",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Teacher").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="David Balisi",LastName="Chakalisa",BirthDate=DateTime.ParseExact("13/03/1970","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="43816101",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Risk Professional").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Miss").ID,
                            FirstName="Keone",LastName="Letsapa",BirthDate=DateTime.ParseExact("20/06/1978","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="486429704",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Counsellor").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Ofentse",LastName="Morebodi",BirthDate=DateTime.ParseExact("18/12/1982","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="499717505",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Engineer").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mrs").ID,
                            FirstName="Mmabatho",LastName="Hauya",BirthDate=DateTime.ParseExact("16/11/1962","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="102927100",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Nurse").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Tshegofatso",LastName="Sello",BirthDate=DateTime.ParseExact("16/04/1985","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="219920419",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Pharmacist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Olefile Sane",LastName="Rapoo",BirthDate=DateTime.ParseExact("09/03/1972","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="619115501",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Lawyer").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Abel",LastName="Alfred",BirthDate=DateTime.ParseExact("07/01/1964","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="554410807",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Consultant").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Dr").ID,
                            FirstName="Edward",LastName="Samsam",BirthDate=DateTime.ParseExact("04/02/1967","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="151418601",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Doctor").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Mothusi",LastName="Malau",BirthDate=DateTime.ParseExact("14/09/1990","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="947011517",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Banker").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Onalethata Bond",LastName="Mpatane",BirthDate=DateTime.ParseExact("05/05/1980","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="492322402",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Teacher").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Uanita Lee",LastName="Vos",BirthDate=DateTime.ParseExact("05/01/1976","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="81621709",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Nurse").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Mr").ID,
                            FirstName="Kentsifetse",LastName="Thomo",BirthDate=DateTime.ParseExact("11/06/1981","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Male,IDNumber="235016002",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Health Worker").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Kebitsaone",LastName="Serefhete",BirthDate=DateTime.ParseExact("27/07/1976","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="688920702",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Banker").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Gugulethu",LastName="Ndebele",BirthDate=DateTime.ParseExact("06/06/1979","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="EN022226",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Consultant").ID,CountryID=countries.Single(m => m.Name =="Zimbabwe").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Loago Sunduh",LastName="Moshaga",BirthDate=DateTime.ParseExact("17/11/1983","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="419123611",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Dentist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID},
                    new Client { ClientTypeID=clienttypes.Single(m => m.Name =="Individual").ID,TitleID=titles.Single(m => m.Name =="Ms").ID,
                            FirstName="Boatametse Linah",LastName="Molapisi-Chirwa",BirthDate=DateTime.ParseExact("15/08/1980","dd'/'MM'/'yyyy",
                            CultureInfo.CurrentCulture.DateTimeFormat),Gender=Gender.Female,IDNumber="699320900",Phone="64532783",Email="someone@gmail.com",PayeeClassID=3,Payable=false,
                            OccupationID=occupations.Single(m => m.Name =="Dentist").ID,CountryID=countries.Single(m => m.Name =="Botswana").ID}
                };
                foreach (Client c in clients)
                {
                    context.Clients.Add(c);
                }
                context.SaveChanges();

                var productclients = new ProductClient[]
                {
                   new ProductClient { ProductID=products.Single(m => m.Name =="Government Employees Motor").ID,
                       ClientID =clients.Single(m => m.IDNumber =="718614601").ID},
                   new ProductClient { ProductID=products.Single(m => m.Name =="Government Employees Motor").ID,
                       ClientID =clients.Single(m => m.IDNumber =="214412205").ID},
                   new ProductClient { ProductID=products.Single(m => m.Name =="Government Employees Motor").ID,
                       ClientID =clients.Single(m => m.IDNumber =="108221609").ID},
                   new ProductClient { ProductID=products.Single(m => m.Name =="Government Employees Property").ID,
                       ClientID =clients.Single(m => m.IDNumber =="848515605").ID},
                   new ProductClient { ProductID=products.Single(m => m.Name =="Government Employees Property").ID,
                       ClientID =clients.Single(m => m.IDNumber =="412323204").ID},
                   new ProductClient { ProductID=products.Single(m => m.Name =="Government Employees Property").ID,
                       ClientID =clients.Single(m => m.IDNumber =="808020004").ID},
                   new ProductClient { ProductID=products.Single(m => m.Name =="Pula Cover").ID,
                       ClientID =clients.Single(m => m.IDNumber =="723512304").ID},
                   new ProductClient { ProductID=products.Single(m => m.Name =="Pula Cover").ID,
                       ClientID =clients.Single(m => m.IDNumber =="803011804").ID},
                   new ProductClient { ProductID=products.Single(m => m.Name =="Pula Cover").ID,
                       ClientID =clients.Single(m => m.IDNumber =="718924001").ID}
                };
                foreach (ProductClient p in productclients)
                {
                    context.ProductClients.Add(p);
                }
                context.SaveChanges();
            }
        }
    }
}

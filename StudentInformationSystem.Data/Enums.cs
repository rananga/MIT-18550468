using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Data
{
    public static class PermissionConstants
    {
        public const string Admin = "Admin";
        public const string AdminUser = "AdminUser";
    }

    public enum Log4NetMsgType
    {
        Error = 0,
        Warning = 1,
        Info = 2
    }

    public enum ActiveState
    {
        [Description("Active")]
        Active = 1,
        [Description("Inactive")]
        Inactive = 0
    }

    public enum Gender
    {
        [Description("Male")]
        Male = 0,
        [Description("Female")]
        Female = 1
    }

    public enum TitleStaff
    {
        [Description("Rev")]
        Rev = 0,
        [Description("Ven")]
        Ven = 1,
        [Description("Prof")]
        Prof = 2,
        [Description("Dr")]
        Dr = 3,
        [Description("Mr")]
        Mr = 4,
        [Description("Mrs")]
        Mrs = 5,
        [Description("Ms")]
        Ms = 6
    }
    public enum Relationship
    {
        [Description("Father")]
        Father = 0,
        [Description("Mother")]
        Mother = 1,
        [Description("Guardian")]
        Guardian = 2,
        [Description("Other")]
        Other = 4
    }
    public enum SibRelationship
    {
        [Description("Elder Brother")]
        ElderBrother = 0,
        [Description("Younger Brother")]
        YoungerBrother = 1,
        [Description("Twin Brother")]
        TwinBrother = 2
    }
    public enum Grades
    {
        [Description("Grade 01")]
        Grade1 = 1,
        [Description("Grade 02")]
        Grade2 = 2,
        [Description("Grade 03")]
        Grade3 = 3,
        [Description("Grade 04")]
        Grade4 = 4,
        [Description("Grade 05")]
        Grade5 = 5,
        [Description("Grade 06")]
        Grade6 = 6,
        [Description("Grade 07")]
        Grade7 = 7,
        [Description("Grade 08")]
        Grade8 = 8,
        [Description("Grade 09")]
        Grade9 = 9,
        [Description("Grade 10")]
        Grade10 = 10,
        [Description("Grade 11")]
        Grade11 = 11,
        [Description("Grade 12")]
        Grade12 = 12,
        [Description("Grade 13")]
        Grade13 = 13
    }
    public enum Classes
    {
        [Description("A")]
        A = 1,
        [Description("B")]
        B = 2,
        [Description("C")]
        C = 3,
        [Description("D")]
        D = 4,
        [Description("E")]
        E = 5,
        [Description("F")]
        F = 6,
        [Description("G")]
        G = 7,
        [Description("H")]
        H = 8,
        [Description("I")]
        I = 9,
        [Description("J")]
        J = 10,
        [Description("K")]
        K = 11,
        [Description("L")]
        L = 12,
        [Description("M")]
        M = 13,
        [Description("EE-M")]
        EE_M = 14,
        [Description("EE-B")]
        EE_B = 15,
        [Description("T")]
        T = 16
    }

    public enum Medium
    {
        [Description("Sinhala")]
        Sinhala = 0,
        [Description("English")]
        English = 1
    }
    public enum StudStatus
    {
        [Description("Active")]
        Active = 0,
        [Description("Inactive")]
        Inactive = 1,
        [Description("On Leave")]
        OnLeave = 2,
        [Description("Transferred")]
        Transferred = 3
    }
    public enum ActiveStatus
    {
        [Description("Active")]
        Active = 0,
        [Description("Inactive")]
        Inactive = 1
    }
    public enum QualificationType
    {
        [Description("Diploma")]
        Diploma = 0,
        [Description("Degree")]
        Degree = 1,
        [Description("Master")]
        Master = 2,
        [Description("PHD")]
        PHD = 3
    }

    public enum Term
    {
        [Description("Term 1")]
        Term1 = 0,
        [Description("Term 2")]
        Term2 = 1,
        [Description("Term 3")]
        Term3 = 2
    }

    public enum Conduct
    {
        [Description("Excellent")]
        Excellent = 0,
        [Description("Very Good")]
        VeryGood = 1,
        [Description("Satisfactory")]
        Satisfactory = 2
    }

    public enum PromotingCriteria
    {
        [Description("Continue The Same Class")]
        ContinueTheSameClass = 0,
        [Description("Shuffle By Admission No")]
        ShuffleByAdmissionNo = 1,
        [Description("Shuffle By Term-1 Marks")]
        ShuffleByTerm1Marks = 2,
        [Description("Shuffle By Term-2 Marks")]
        ShuffleByTerm2Marks = 3,
        [Description("Shuffle By Term-3 Marks")]
        ShuffleByTerm3Marks = 4,
        [Description("Shuffle By All Marks")]
        ShuffleByAllMarks = 5
    }

    public enum MarksReportOrderBy
    {
        [Description("Average Marks")]
        Average = 0,
        [Description("Term 1 Marks")]
        Term1 = 1,
        [Description("Term 2 Marks")]
        Term2 = 2,
        [Description("Term 3 Marks")]
        Term3 = 3,
    }

    public enum SyncType
    {
        CreateCourse,
        DeleteCourse,
        UpdateCourse,
        CreateStudent,
        ResetPassword,
        CreateTeacher,
        UpdateTeacher
    }

    public enum BloodGroup
    {
        Unknown = 0,
        A_Positive = 1,
        A_Negative = 2,
        B_Positive = 3,
        B_Negative = 4,
        O_Positive = 5,
        O_Negative = 6,
        AB_Positive = 7,
        AB_Negative = 8
    }

    public enum MaritalStatus
    {
        Unknown = 0,
        Married = 1,
        Devorced = 2,
        Separated = 3
    }

    public enum ParentsDeceased
    {
        NoBothLiving = 0,
        YesFather = 1,
        YesMother = 2,
        BothDeceased = 3
    }

    public enum TransportMode
    {
        Walking = 0,
        SchoolHostel = 1,
        PublicTransport_Bus = 2,
        PublicTransport_Train = 3,
        SchoolBus = 4,
        PrivateVehicle = 5,
        SchoolVan = 6
    }

    public enum DivisionalSecretariat
    {
        Addalachchenai = 1,
        Agalawatta = 2,
        Akkaraipattu = 3,
        Akmeemana = 4,
        Akurana = 5,
        Akuressa = 6,
        Alawwa = 7,
        Alayadiwembu = 8,
        Ambagamuwa = 9,
        Ambalangoda = 10,
        Ambalantota = 11,
        AmbangangaKorale = 12,
        Ambanpola = 13,
        Ampara = 14,
        Anamaduwa = 15,
        Angunakolapelessa = 16,
        Arachchikattuwa = 17,
        Aranayaka = 18,
        Athuraliya = 19,
        Attanagalla = 20,
        Ayagama = 21,
        Badalkumbura = 22,
        Baddegama = 23,
        Badulla = 24,
        Balangoda = 25,
        Balapitiya = 26,
        Bamunakotuwa = 27,
        Bandaragama = 28,
        Bandarawela = 29,
        Beliatta = 30,
        Benthota = 31,
        Beruwala = 32,
        Bibile = 33,
        Bingiriya = 34,
        Biyagama = 35,
        BopePoddala = 36,
        Bulathkohupitiya = 37,
        Bulathsinhala = 38,
        Buttala = 39,
        Chilaw = 40,
        Colombo = 41,
        Damana = 42,
        Dambulla = 43,
        Dankotuwa = 44,
        Dehiattakandiya = 45,
        Dehiovita = 46,
        Dehiwala = 47,
        Delft = 48,
        Delthota = 49,
        Deraniyagala = 50,
        Devinuwara = 51,
        Dickwella = 52,
        Dimbulagala = 53,
        Divulapitiya = 54,
        Dodangoda = 55,
        Doluwa = 56,
        Dompe = 57,
        Eheliyagoda = 58,
        Ehetuwewa = 59,
        Elahera = 60,
        Elapattha = 61,
        Ella = 62,
        Elpitiya = 63,
        Embilipitiya = 64,
        Eragama = 65,
        EravurPattu = 66,
        EravurTown = 67,
        GagawataKorale = 68,
        Galenbindunuwewa = 69,
        Galewela = 70,
        Galgamuwa = 71,
        Galigamuwa = 72,
        Galle = 73,
        Galnewa = 74,
        Gampaha = 75,
        Ganewatta = 76,
        GangaIhalaKorale = 77,
        Giribawa = 78,
        Godakawela = 79,
        Gomarankadawala = 80,
        Gonapinuwala = 81,
        Habaraduwa = 82,
        Hakmana = 83,
        Haldummulla = 84,
        HaliEla = 85,
        Hambantota = 86,
        Hanguranketha = 87,
        Haputale = 88,
        Harispattuwa = 89,
        Hatharaliyadda = 90,
        Hikkaduwa = 91,
        Hingurakgoda = 92,
        Homagama = 93,
        Horana = 94,
        Horowpothana = 95,
        Ibbagamuwa = 96,
        Imaduwa = 97,
        Imbulpe = 98,
        Ingiriya = 99,
        Ipalogama = 100,
        IslandNorth = 101,
        IslandSouth = 102,
        JaEla = 103,
        Jaffna = 104,
        Kaduwela = 105,
        Kahatagasdigiliya = 106,
        Kahawatta = 107,
        Kalawana = 108,
        KalmunaiMuslim = 109,
        KalmunaiTamil = 110,
        Kalpitiya = 111,
        Kalutara = 112,
        Kamburupitiya = 113,
        Kandaketiya = 114,
        Kandavalai = 115,
        Kantalai = 116,
        Karachchi = 117,
        Karainagar = 118,
        Karaitivu = 119,
        Karandeniya = 120,
        Karuwalagaswewa = 121,
        Katana = 122,
        Katharagama = 123,
        Kattankudy = 124,
        Katupotha = 125,
        Katuwana = 126,
        Kebithigollewa = 127,
        Kegalle = 128,
        Kekirawa = 129,
        Kelaniya = 130,
        Kesbewa = 131,
        Kinniya = 132,
        Kiriella = 133,
        KirindaPuhulwella = 134,
        Kobeigane = 135,
        Kolonna = 136,
        Kolonnawa = 137,
        KoralaiPattu = 138,
        KoralaiPattuCentral = 139,
        KoralaiPattuNorth = 140,
        KoralaiPattuSouth = 141,
        KoralaiPattuWest = 142,
        Kotapola = 143,
        Kotavehera = 144,
        Kothmale = 145,
        Kotte = 146,
        Kuchchaveli = 147,
        KuliyapitiyaEast = 148,
        KuliyapitiyaWest = 149,
        Kundasale = 150,
        Kurunegala = 151,
        Kuruvita = 152,
        LaggalaPallegama = 153,
        Lahugala = 154,
        Lankapura = 155,
        Lunugala = 156,
        Lunugamvehera = 157,
        Madampe = 158,
        Madhu = 159,
        Madulla = 160,
        Madurawela = 161,
        Mahakumbukkadawala = 162,
        Mahaoya = 163,
        Mahara = 164,
        Maharagama = 165,
        Mahavilachchiya = 166,
        Mahawa = 167,
        Mahawewa = 168,
        Mahiyanganaya = 169,
        Malimbada = 170,
        Mallawapitiya = 171,
        ManmunaiNorth = 172,
        ManmunaiPattu = 173,
        Manmunai_S_AndEruvilPattu = 174,
        ManmunaiSouthWest = 175,
        ManmunaiWest = 176,
        Mannar = 177,
        ManthaiEast = 178,
        ManthaiWest = 179,
        Maritimepattu = 180,
        Maspotha = 181,
        Matale = 182,
        Matara = 183,
        Mathugama = 184,
        Mawanella = 185,
        Mawathagama = 186,
        Medadumbara = 187,
        Medagama = 188,
        Medawachchiya = 189,
        Medirigiriya = 190,
        Meegahakivula = 191,
        Mihinthale = 192,
        Millaniya = 193,
        Minipe = 194,
        Minuwangoda = 195,
        Mirigama = 196,
        Moneragala = 197,
        Moratuwa = 198,
        Morawewa = 199,
        Mulatiyana = 200,
        Mundalama = 201,
        Musalai = 202,
        Muttur = 203,
        Nachchadoowa = 204,
        Nagoda = 205,
        Nallur = 206,
        Nanaddan = 207,
        Narammala = 208,
        Nattandiya = 209,
        Naula = 210,
        Navithanveli = 211,
        Nawagattegama = 212,
        Negombo = 213,
        Neluwa = 214,
        Nikaweratiya = 215,
        Ninthavur = 216,
        Nivithigala = 217,
        Niyagama = 218,
        Nochchiyagama = 219,
        NuwaraEliya = 220,
        NuwaragamPalathaCentral = 221,
        NuwaragamPalathaEast = 222,
        Oddusuddan = 223,
        Okewela = 224,
        Opanayaka = 225,
        Pachchilaipalli = 226,
        PadaviSriPura = 227,
        Padaviya = 228,
        Padiyathalawa = 229,
        Padukka = 230,
        Palagala = 231,
        Palindanuwara = 232,
        Pallama = 233,
        Pallepola = 234,
        Palugaswewa = 235,
        Panadura = 236,
        Panduwasnuwara = 237,
        Pannala = 238,
        Panvila = 239,
        PasbageKorale = 240,
        Pasgoda = 241,
        Passara = 242,
        Pathadumbara = 243,
        Pathahewaheta = 244,
        Pelmadulla = 245,
        Pitabeddara = 246,
        Polgahawela = 247,
        Polpithigama = 248,
        Poojapitiya = 249,
        Poonakary = 250,
        PorativuPattu = 251,
        Pothuvil = 252,
        Puthukudiyiruppu = 253,
        Puttalam = 254,
        Rajanganaya = 255,
        Rambewa = 256,
        Rambukkana = 257,
        Rasnayakapura = 258,
        Ratmalana = 259,
        Ratnapura = 260,
        Rattota = 261,
        Rideegama = 262,
        Rideemaliyadda = 263,
        Ruwanwella = 264,
        Sainthamarathu = 265,
        Samanthurai = 266,
        Seethawaka = 267,
        Seruvila = 268,
        Sevanagala = 269,
        Siyambalanduwa = 270,
        Sooriyawewa = 271,
        Soranathota = 272,
        Tangalle = 273,
        Thalawa = 274,
        Thamankaduwa = 275,
        Thambalagamuwa = 276,
        Thambuttegama = 277,
        Thanamalvila = 278,
        Thawalama = 279,
        Thenmaradchi = 280,
        Thihagoda = 281,
        Thimbirigasyaya = 282,
        Thirappane = 283,
        Thirukkovil = 284,
        Thissamaharama = 285,
        Thumpane = 286,
        Thunukkai = 287,
        Trincomalee = 288,
        Udadumbara = 289,
        Udapalatha = 290,
        Udubaddawa = 291,
        Udunuwara = 292,
        Uhana = 293,
        Ukuwela = 294,
        UvaParanagama = 295,
        VadamaradchiEast = 296,
        VadamaradchiNorth = 297,
        VadamaradchiSouthWest = 298,
        ValikamamEast = 299,
        ValikamamNorth = 300,
        ValikamamSouth = 301,
        ValikamamSouthWest = 302,
        ValikamamWest = 303,
        Vanathavilluwa = 304,
        Vavuniya = 305,
        VavuniyaNorth = 306,
        VavuniyaSouth = 307,
        Vengalacheddikulam = 308,
        Verugal = 309,
        Walallavita = 310,
        Walapane = 311,
        Walasmulla = 312,
        Warakapola = 313,
        Wariyapola = 314,
        Wattala = 315,
        Weeraketiya = 316,
        Weerambugedara = 317,
        Weligama = 318,
        Weligepola = 319,
        Welikanda = 320,
        Welimada = 321,
        Welioya = 322,
        Welipitiya = 323,
        WelivitiyaDivithura = 324,
        Wellawaya = 325,
        Wennappuwa = 326,
        Wilgamuwa = 327,
        Yakkalamulla = 328,
        Yatawatta = 329,
        Yatinuwara = 330,
        Yatiyanthota = 331
    }
}
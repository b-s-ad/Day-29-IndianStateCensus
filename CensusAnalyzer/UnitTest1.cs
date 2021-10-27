using NUnit.Framework;
using IndianStateCensusAnalyzer;
using System.Collections.Generic;
using IndianStateCensusAnalyzer.DTO;
using static IndianStateCensusAnalyzer.CensusAnalyser;


namespace Tests
{
    public class Tests
    {

        //CensusAnalyser.CensusAnalyser censusAnalyser;

        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\IndiaStateCensusData.csv";// 1.1
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\WrongIndiaStateCensusData.csv"; //1.5

        static string delimiterIndianCensusFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\DelimiterIndiaStateCensusData.csv"; //1.4
        static string wrongIndianStateCensusFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\IndiaData.csv";//1.1 //1.2
        static string indianStateCensusFilePaths = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\IndiaStateData.csv";//1.2
        static string wrongIndianStateCensusFileType = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\IndiaStateCensusData.txt";//1.3
        static string indianStateCodeFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\IndiaStateCode.csv";//1.1
        static string wrongIndianStateCodeFileType = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\IndiaStateCode.txt";//1.3
        static string delimiterIndianStateCodeFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\DelimiterIndiaStateCode.csv";//1.4
        static string wrongHeaderStateCodeFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\WrongIndiaStateCode.csv";//1.5
        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\USCensusData.csv";
        static string wrongUSCensusFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\USCsvFiles\USData.csv";
        static string wrongUSCensusFileType = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"C:\Users\Userr\source\repos\CensusAnalyzer\Csvfiles\DelimiterUSCensusData.csv";


        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        /*[Test]//1.1
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

       [Test]//1.2
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
             var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(indianStateCensusFilePaths, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        */
        [Test]//1.3
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
/*
        [Test]//1.4
        public void GivenIndianCensusDataFile_WhenDELIMITERnotproper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA,  indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA,  indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        [Test]//1.5
        public void GivenIndianCensusDataFile_WhenHEADERnotproper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

*/



    }
}   
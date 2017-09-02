using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParadeCore.Test.Dictionaries
{
    public class RanksDictionary_Should
    {
        [Theory]
        [InlineData(Rank.Private, RankModifier.Standard, "Private", "Pte")]
        public void ReturnExpectedValuesWhenAllParametersProvided(Rank rank, RankModifier modifier, string expectedName, string expectedAbbreviation)
        {
            var result = ParadeCore.Dictionaries.RankDictionary.Lookup(rank, modifier);

            Assert.True(result.name.Equals(expectedName));
            Assert.True(result.abbreviation.Equals(expectedAbbreviation));
        }

        [Theory]
        [InlineData(Rank.PrivateRecruit, "Private (Recruit)", "Pte(R)")]
        [InlineData(Rank.PrivateBasic, "Private (Basic)", "Pte(B)")]
        [InlineData(Rank.Private, "Private", "Pte")]
        [InlineData(Rank.Corporal, "Corporal", "Cpl")]
        [InlineData(Rank.MasterCorporal, "Master Corporal", "MCpl")]
        [InlineData(Rank.Sergeant, "Sergeant", "Sgt")]
        [InlineData(Rank.WarrantOfficer, "Warrant Officer", "WO")]
        [InlineData(Rank.MasterWarrantOfficer, "Master Warrant Officer", "MWO")]
        [InlineData(Rank.ChiefWarrantOfficer, "Chief Warrant Officer", "CWO")]
        public void ReturnStandardNcoRanksWhenNoModifierProvided(Rank rank, string expectedName, string expectedAbbreviation)
        {
            var result = ParadeCore.Dictionaries.RankDictionary.Lookup(rank);

            Assert.True(result.name.Equals(expectedName));
            Assert.True(result.abbreviation.Equals(expectedAbbreviation));
        }

        [Theory]
        [InlineData(Rank.PrivateRecruit, RankModifier.Navy, "Ordinary Seaman (Recruit)", "OS(R)")]
        [InlineData(Rank.PrivateBasic, RankModifier.Navy, "Ordinary Seaman (Basic)", "OS(B)")]
        [InlineData(Rank.Private, RankModifier.Navy, "Ordinary Seaman", "OS")]
        [InlineData(Rank.Corporal, RankModifier.Navy, "Able Seaman", "AS")]
        [InlineData(Rank.MasterCorporal, RankModifier.Navy, "Master Seaman", "MS")]
        [InlineData(Rank.Sergeant, RankModifier.Navy, "Petty Officer 2nd Class", "PO2")]
        [InlineData(Rank.WarrantOfficer, RankModifier.Navy, "Petty Officer 1st Class", "PO1")]
        [InlineData(Rank.MasterWarrantOfficer, RankModifier.Navy, "Chief Petty Officer 2nd Class", "CPO2")]
        [InlineData(Rank.ChiefWarrantOfficer, RankModifier.Navy, "Chief Petty Officer 1st Class", "CPO1")]
        public void ReturnExpectedNavalNcoRanks(Rank rank, RankModifier modifier, string expectedName, string expectedAbbreviation)
        {
            var result = ParadeCore.Dictionaries.RankDictionary.Lookup(rank, modifier);

            Assert.True(result.name.Equals(expectedName));
            Assert.True(result.abbreviation.Equals(expectedAbbreviation));
        }

        [Theory]
        [InlineData(Rank.PrivateRecruit, RankModifier.AirForce, "Aviator (Recruit)", "Avr(R)")]
        [InlineData(Rank.PrivateBasic, RankModifier.AirForce, "Aviator (Basic)", "Avr(B)")]
        [InlineData(Rank.Private, RankModifier.AirForce, "Aviator", "Avr")]
        public void ReturnExpectedAirForceNcoRanks(Rank rank, RankModifier modifier, string expectedName, string expectedAbbreviation)
        {
            var result = ParadeCore.Dictionaries.RankDictionary.Lookup(rank, modifier);

            Assert.True(result.name.Equals(expectedName));
            Assert.True(result.abbreviation.Equals(expectedAbbreviation));
        }
    }
}

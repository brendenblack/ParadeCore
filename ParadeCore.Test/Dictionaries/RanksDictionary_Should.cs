using ParadeCore.Domain.Dictionaries;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParadeCore.Test.Dictionaries
{
    public class RanksDictionary_Should
    {
        [Theory]
        [InlineData(RankEquivalence.Private, RankModifier.Standard, "Private", "Pte")]
        public void ReturnExpectedValuesWhenAllParametersProvided(RankEquivalence rank, RankModifier modifier, string expectedName, string expectedAbbreviation)
        {
            var result = RankDictionary.Lookup(rank, modifier);

            Assert.True(result.name.Equals(expectedName));
            Assert.True(result.abbreviation.Equals(expectedAbbreviation));
        }

        [Theory]
        [InlineData(RankEquivalence.PrivateRecruit, "Private (Recruit)", "Pte(R)")]
        [InlineData(RankEquivalence.PrivateBasic, "Private (Basic)", "Pte(B)")]
        [InlineData(RankEquivalence.Private, "Private", "Pte")]
        [InlineData(RankEquivalence.Corporal, "Corporal", "Cpl")]
        [InlineData(RankEquivalence.MasterCorporal, "Master Corporal", "MCpl")]
        [InlineData(RankEquivalence.Sergeant, "Sergeant", "Sgt")]
        [InlineData(RankEquivalence.WarrantOfficer, "Warrant Officer", "WO")]
        [InlineData(RankEquivalence.MasterWarrantOfficer, "Master Warrant Officer", "MWO")]
        [InlineData(RankEquivalence.ChiefWarrantOfficer, "Chief Warrant Officer", "CWO")]
        public void ReturnStandardNcoRanksWhenNoModifierProvided(RankEquivalence rank, string expectedName, string expectedAbbreviation)
        {
            var result = RankDictionary.Lookup(rank);

            Assert.True(result.name.Equals(expectedName));
            Assert.True(result.abbreviation.Equals(expectedAbbreviation));
        }

        [Theory]
        [InlineData(RankEquivalence.PrivateRecruit, RankModifier.Navy, "Ordinary Seaman (Recruit)", "OS(R)")]
        [InlineData(RankEquivalence.PrivateBasic, RankModifier.Navy, "Ordinary Seaman (Basic)", "OS(B)")]
        [InlineData(RankEquivalence.Private, RankModifier.Navy, "Ordinary Seaman", "OS")]
        [InlineData(RankEquivalence.Corporal, RankModifier.Navy, "Able Seaman", "AS")]
        [InlineData(RankEquivalence.MasterCorporal, RankModifier.Navy, "Master Seaman", "MS")]
        [InlineData(RankEquivalence.Sergeant, RankModifier.Navy, "Petty Officer 2nd Class", "PO2")]
        [InlineData(RankEquivalence.WarrantOfficer, RankModifier.Navy, "Petty Officer 1st Class", "PO1")]
        [InlineData(RankEquivalence.MasterWarrantOfficer, RankModifier.Navy, "Chief Petty Officer 2nd Class", "CPO2")]
        [InlineData(RankEquivalence.ChiefWarrantOfficer, RankModifier.Navy, "Chief Petty Officer 1st Class", "CPO1")]
        public void ReturnExpectedNavalNcoRanks(RankEquivalence rank, RankModifier modifier, string expectedName, string expectedAbbreviation)
        {
            var result = RankDictionary.Lookup(rank, modifier);

            Assert.True(result.name.Equals(expectedName));
            Assert.True(result.abbreviation.Equals(expectedAbbreviation));
        }

        [Theory]
        [InlineData(RankEquivalence.PrivateRecruit, RankModifier.AirForce, "Aviator (Recruit)", "Avr(R)")]
        [InlineData(RankEquivalence.PrivateBasic, RankModifier.AirForce, "Aviator (Basic)", "Avr(B)")]
        [InlineData(RankEquivalence.Private, RankModifier.AirForce, "Aviator", "Avr")]
        public void ReturnExpectedAirForceNcoRanks(RankEquivalence rank, RankModifier modifier, string expectedName, string expectedAbbreviation)
        {
            var result = RankDictionary.Lookup(rank, modifier);

            Assert.True(result.name.Equals(expectedName));
            Assert.True(result.abbreviation.Equals(expectedAbbreviation));
        }
    }
}

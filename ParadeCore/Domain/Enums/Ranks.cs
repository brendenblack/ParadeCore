using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadeCore
{
    public enum RankEquivalence
    {
        Civilian = -1,
        PrivateRecruit = 0,
        PrivateBasic =1,
        Private,
        Corporal,
        MasterCorporal,
        Sergeant,
        WarrantOfficer,
        MasterWarrantOfficer,
        ChiefWarrantOfficer,
        OfficerCadet,
        SecondLieutenant,
        Lieutenant,
        Captain,
        Major,
        LieutenantColonel,
        Colonel,
        BrigadierGeneneral,
        MajorGeneral,
        LieutenantGeneral,
        General
    }

    public enum RankModifier
    {
        Standard = 0,
        Navy,
        AirForce,
        Rifles,
        Fusilier,
        Artillery,
        Armoured
    }
}

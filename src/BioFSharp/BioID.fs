﻿namespace BioFSharp

// 
module BioID =

    open System
    open FSharp.Care


    /// NCBI Reference Sequence Database
    type RefSeqId = RefSeqId of string

    // Model RefSeq:  RNA and protein products that are generated by the eukaryotic genome annotation pipeline. These records use accession prefixes XM_, XR_, and XP_.
    // Known RefSeq: RNA and protein products that are mainly derived from GenBank cDNA and EST data and are supported by the RefSeq eukaryotic curation group. These records use accession prefixes NM_, NR_, and NP_.
    /// Parse NCBI RefSeqId (Reference Sequence Database identifier) EXAMPLE: 'NC_003070.9'.
    /// Returns Failure string in case of no match.
    let parseRefSeqId = Regex.tryEitherParse RefSeqId @"(NC|AC|NG|NT|NW|NZ|NM|NR|XM|XR|NP|AP|XP|YP|ZP)_[0-9.]+"     

    // Example:
    //"NC_003070.9" |> parseRefSeqId

    /// NCBI Reference Sequence Database
    type CreId = 
        | CreId  of string
        | CreSId of string

    /// Parse NCBI RefSeqId (Reference Sequence Database identifier) EXAMPLE: 'NC_003070.9'.
    /// Returns Failure string in case of no match.
    let parseCreId  = Regex.tryEitherParse CreId @"Cre[\d]*\.g[\d]*\.t[\d]*\.[\d]*"    
    let parseCreSId = Regex.tryEitherParse CreSId @"Cre[\d]*\.g[\d]*"  

    // Example:
    //"Cre06.g1000.t1.1" |> parseCreId


    // Finde regex: http://bioportal.bioontology.org/ontologies/EDAM?p=classes&conceptid=data_1098
    // TEst regex : http://regexstorm.net/tester
    // https://blog.mariusschulz.com/2014/04/10/practical-use-cases-for-the-regexoptions-flags




    type YeastId =
        //Systematic names for nuclear-encoded ORFs begin with the letter 'Y' (for 'Yeast'); the second letter denotes the chromosome number 
        //('A' is chr I, 'B' is chr II, etc.); the third letter is either 'L' or 'R' for left or right chromosome arm; next is a three digit 
        //number indicating the order of the ORFs on that arm of a chromosome starting from the centromere, irrespective of strand; finally,
        //there is an additional letter indicating the strand, either 'W' for Watson (the strand with 5' end at the left telomere) or 'C' for Crick (the complement strand, 5' end is at the right telomere).
        | SystematicName  of string 
        | SgdId of string

    let stringFromYeastId yid =
        match yid with
        | YeastId.SystematicName name -> name
        | YeastId.SgdId id            -> id

    let parseSgdId   = Regex.tryEitherParse SgdId @"SGDID:\w\d+"    
    let parseYeastSN = Regex.tryEitherParse SystematicName @"((Y|R).(L|R)?[0-9]{3}(C|W))|(Q[0-9]{4})"  

    // Example:
    //"YAL001C TFC3 SGDID:S000000001" |> parseSgdId
    //"R0010W" |> parseYeastSN 
    

    // <IDspace_name>:<identifier>
    // http://oboedit.org/docs/html/An_Introduction_to_OBO_Ontologies.htm
    type Obo =
        | Id of string * string

    //let parseOboId  = Regex.tryEitherParse Obo.Id @"[\w]+:(?<goId>[\d]+)"

    
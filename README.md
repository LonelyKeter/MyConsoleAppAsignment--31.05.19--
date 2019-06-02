# MyConsoleAppAsignment--31.05.19--

This is my solution for an xls/xlsx file reader console application.

Input:

    All arguments should be passed to a program when it is called.

    Argument format:
    
        1. -{flags} {key1} {key2} ... {keyN} {filepath}    
        Represents search results through file at the {filepath} using passed {flags}.
    
        2. {key1} {key2} ... {keyN} {filepath}    
        Represents search results through file at the {filepath} using default flags.
        
    Flags:
        Safe:
            -c  Key match count will be shown
            -n  Key matching cell's names will be shown
            -s  Sheet names, which have key matching cells will ne shown
            -k  Search results will be shown separately for each passed {key} value
                Implecetly uses default flags, if passed alone (" -k {key1} ... {filename} ")
        Unsafe:
            -u  Allows reading files, that have unsupported extension (can cause unpredictable result)
        Default:
            -cns
            
Output:
      
    {key} :
    {sheetname1.cellname11}
    {sheetname1.cellname12}
    -----------------------
    {sheetname1.cellname1K}
    {sheet1 count}
    {sheetname2.cellname21}
    {sheetname2.cellname22}
    -----------------------
    {sheetnameN.cellnameNK}
    {sheetN count}
    
    {file count}
    
    This is general output view. Some fields may be missing depending on {flags}.
    
    
 Architecture:
 
    Demands:
        Main. Application should read an xls/xlsx file. A target file adress is passed as a parameter.
              Only free opensource libraries (those, which don't restrict theirs usage in commercials) should be used in development. 
        Sub1. Application should work properly on servers, which don't have MSOffice libraries installed.
        Sub2. Application should provide functionality for searching data from read file and represent search results giving information about cell name, match count and sheet name.
        Sub4. Application shouldn't strongly rely on used libraries so that additional libraries could be used to extend functionality.
 
    Searching process is split in 4 steps:
        -Argument verification
        -File reading
        -Searching
        -Result representation
        
    Each step is incapsulated in its own class (or in case with result representation in a group of classes (wrappers)).
    Each class instance (excluding "Searcher", because it's static) is created with {Classname}.Factory Get- methods.
    
    Brief algorythm review:
        1. Verify arguments. If arguments are wrong, return error message.
        2. Create reader object and read file into LocalDataSet. If file wasn't read, return error message.
        3. Search keys through created LocalDataSet. 
        4. Create result representer using passed {flags}.
        5. Represent results using created representer.                 
        
 -------------------------------------------------------------------------------------------------------------------------------------
        
    Argument verification:
         Argument verification functions are incapsulated in "ArgumentVerifier" class.          
         Each ArgumentVerifier contains its VerifierState, which is passed to ArgumentVerifier.Factory.GetVerifier.         
         State discribes how verifier should interpret passed arguments. At the moment VerifierState contains only 
         VerifierOptions enum value.         
         Then, Verify() method should be called. Returned value indicates result of verification.
         
--------------------------------------------------------------------------------------------------------------------------------------
         
    File readilng:
         As long, as the application should support adding problem solution implementing with additional libraries, it was decided
         to split searching process in reading and searching. Different libraries can read xml/xmlsx in different custom data types,
         but also it's natural that most of them should support reading into System data type, so it was decided, that on redaing 
         step any Reader implementation sholud return System.Data.DataSet. Thus, common reader interface, IReader, was created.
         Also, it was decided to create custom wrapper around System.Data.DataSet -- LocalDataSet -- to bring some control to DataSet 
         creation. Each Reader should implement IReader interface.  Each IReader implementation contains State and Set properies and
         Read() method.
         
         State: ReaderState struct, that defines the way file will be read. At the moment only contains ReaderOptions
         enum value, which tells weather to read or not file, that doesn't have supported extension (corresponds to -u flag). 
         
         Set: LocalDataSet, where file will be read to.
         
         Read(): Tries to read path at the passed filepath. Returns true, if succeded, otherwise false.
         
         Currently there's only one Reader implementation, EDRReader, based on free opensource library ExcelDataReader, which has 
         an extension to read xml/xnls/CSV directly into System.Data.DataSet.
         
         EDRReader: Reads xls/slxd/csv. In safe context tries to read only supported file formats. In unsafe context first tries to
         read file as xls/xlsx, and then, if fails, tries to read as a csv file (which is basically formatted .txt, so it can cause
         unpredictible results). Unsafe flag should be used carefully.
         
--------------------------------------------------------------------------------------------------------------------------------------
    
    Searching:
        Searching is performed by static Seacher class. It has one single method Search, that takes in an array of string keys and               LocalDataSet and returns SearchResult.
        
        SearchResult: struct containing search result. It has 2 fields: array of keys and array of sub structs Result. Result (struct)
        contains an array of sheet names, sheet counts (match count for single sheet) and queues of cellnames. Each Result corresponds 
        to a certain key in SearchResult.
    
--------------------------------------------------------------------------------------------------------------------------------------
    
    Result representation:
        Representation process is basically a process of building output string using IRepresenter object.
        
        Because flags can vary in pretty wide range the only way of getting IRepresenter object is trough RepresentorFactory.
        RepresentFactory decorates in correct order base Representer class in wrappers corresponding to passed to GetRepresenter()
        method ActionFlags enum value.
        
        Then Represent() method is called. It takes in SerchResult structure and returns StringBuilder, containing ouput string
        
   
         
     

# MyConsoleAppAsignment--31.05.19--

This is my solution for a xls/xlsx file reader console application

Input:
All arguments should be passed to a program when it is called

    Argument format:
    
        1. -{flags} {key1} {key2} ... {keyn} {filepath}    
        Represents search results through file at the {filepath} using passed {flags}
    
        2. {key1} {key2} ... {keyn} {filepath}    
        Represents search results through file at the {filepath} using default flags
        
    Flags:
        Safe:
            -c  Key match count will be shown
            -n  Key matching cell's names will ne shown
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
    
    This is general output view. Some fields may be missing depending on {flags}
     

#include once "aulib/string/AuStringManip.bas"
#include once "aulib/file/AuFile.bas"
#include once "aulib/collection/AuList.bas"

using aulib

type label
    as string lblName
    as ulong addr
end type

declareList(label)

function main(argc as integer, argv as zstring ptr ptr) as integer
    if(argc < 2) then
        print("File not found!")
        return 0
    end if
    
    dim as string currentDir = *argv[0]
    dim as string inputFileName = *argv[1]
    dim as string outputFileName = iif(argc = 3, *argv[2], "a.aex")
    
    dim as AuFile inFile, outFile
    inFile.openRead(inputFileName)
    outFile.openWrite(outputFileName)
    
    
    
    inFile.closeFile()
    outFile.closeFile()
    
    return 0
end function
end main(__FB_ARGC__, __FB_ARGV__)
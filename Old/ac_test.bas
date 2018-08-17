#include "crt.bi"'

sub throwError(message as string)
    printf(!"[ERROR : '%s']\n", message)
    sleep()
    stop
end sub

function getWord(byval text as string, wordIndex as integer, delimiter as string = " ") as string
    dim as zstring ptr word
    dim as integer wordsPassed
    word = strtok(text, delimiter)
    while(word <> NULL)
        wordsPassed+=1
        if(wordsPassed = wordIndex+1) then
            exit while
        end if
        word = strtok(NULL, delimiter)
    wend
    return(*word)
end function

function getWordCount(byval text as string, delimiter as string = " ") as integer
    dim as zstring ptr word
    dim as integer wordsPassed
    word = strtok(text, delimiter)
    while(word <> NULL)
        wordsPassed+=1
        word = strtok(NULL, delimiter)
    wend
    return(wordsPassed)
end function

type CPU_Object
    as ulong ptr register = new ulong[5]
    
private:
    declare function GetRegID(letter as string) as ubyte
    
public:
    declare sub Load(value as ulong, regID as ubyte)
    declare sub Mov(src as ulong, dst as ulong)
    
    declare sub Add(reg1 as ubyte, reg2 as ubyte, destReg as ubyte)
    
    declare sub Eval(stmt as string)
    
    declare sub Dump()
end type

function CPU_Object.GetRegID(letter as string) as ubyte
    letter = ucase(letter)
    if(letter = "A") then return 0
    if(letter = "B") then return 1
    if(letter = "C") then return 2
    if(letter = "D") then return 3
    
    throwError("Invalid register name")
end function

sub CPU_Object.Load(value as ulong, regID as ubyte)
    this.register[regID] = value
end sub

sub CPU_Object.Mov(src as ulong, dst as ulong)
    register[dst] = register[src]
end sub

sub CPU_Object.Add(reg1 as ubyte, reg2 as ubyte, destReg as ubyte)
    this.register[destReg] = this.register[reg1] + this.register[reg2]
end sub

sub CPU_Object.Eval(stmt as string)
    if(len(stmt) = 0) then return
    
    dim as ulong cnt = getWordCount(stmt)
    dim as string ptr token = new string[cnt]
    for i as integer = 0 to cnt-1
        token[i] = getWord(stmt, i)
    next i
    print token[3]
    
    dim as string cmd = ucase(getWord(stmt, 0))
    
    select case cmd
    case "LOAD"
        this.Load(val(getWord(stmt, 1)), this.GetRegID(getWord(stmt, 2)))
    case "MOV"
        this.Mov(this.GetRegID(getWord(stmt, 1)), this.GetRegID(getWord(stmt, 2)))
    case "ADD"
        this.add(this.GetRegID(getWord(stmt, 1)), this.GetRegID(getWord(stmt, 2)), this.GetRegID(getWord(stmt, 3)))
    end select
end sub

sub CPU_Object.Dump()
    printf(!"Registers:\n")
    printf(!"A[%i] B[%i] C[%i] D[%i]\n", register[0], register[1], register[2], register[3])
end sub

dim as CPU_Object CPU

CPU.Eval("LOAD 4 A")
CPU.Eval("MOV A B")
CPU.Eval("ADD A B C")

CPU.Dump()

sleep()
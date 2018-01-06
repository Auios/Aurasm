enum opcode
    none
    mov
    jmp
    mAdd
    mSub
    mMul
    mDiv
    ret
end enum

type hw_CPU
    as ubyte ptr mem
    as ubyte regA
    as ubyte regB
    as ubyte regC
    as ubyte regD
    
    as ubyte ip
    as ubyte fault:1
    as ubyte isRunning:1
    
    declare sub init(size as uinteger)
    declare sub reset()
    declare function load(adr as ubyte) as ubyte
    declare sub start()
    declare sub stop()
    declare sub takeStep()
end type

sub hw_CPU.init(size as uinteger)
    mem = new ubyte[size]
end sub

sub hw_CPU.reset()
    regA = 0
    regB = 0
    regC = 0
    regD = 0
    
    ip = 0
    fault = 0
    isRUnning = 0
end sub

function hw_CPU.load(adr as ubyte) as ubyte
    return mem[adr]
end function

sub hw_CPU.start()
    isRunning = 1

sub hw_CPU.stop()
    isRunning = 0
end sub

sub hw_CPU.takeStep()
    if(fault) then this.stop()
end sub



dim as hw_CPU x

x.a = 1
print x.a
x.a = 2
print x.a
x.a = 3
print x.a

sleep


open System.IO
open AlviSharp.Parser

[<EntryPoint>]
let main argv = 
        let x = File.ReadAllText(argv.[0])
        let y = (ParseAlvis x)
        printfn "%A" y
        0


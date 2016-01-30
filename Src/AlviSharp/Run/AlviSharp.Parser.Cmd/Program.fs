

open System.IO

[<EntryPoint>]
let main argv = 
        let x = File.ReadAllText(argv.[0])
        let y = (AlviSharp.Parser.Program.ParseAlvis x)
        printfn "%A" y
        0


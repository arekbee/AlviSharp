namespace AlviSharp.Parser
open System
open System.IO
open AlvisSpec

module public Program=
    let ParseAlvis x =
    let lexbuf = Lexing.LexBuffer<_>.FromString x
    let y = AlvisParser.start AlvisLexer.tokenize lexbuf
    y


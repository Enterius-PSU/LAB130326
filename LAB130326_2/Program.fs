// Кушев Александр БАС-2
// Лабораторная работа №3 (Задание №2)

open System

// Функция проверки, является ли строка бинарным значением
let checkIfBin str =
    str |> String.forall (
        fun c -> c = '0' || c = '1'
    )

// Функция преобразования бинарной строки в число
let binToInt (str: string) =
    str 
    |> Seq.fold (
        fun acc ch -> acc * 2 + (int ch - int '0')
    ) 0

// Функция получения десятеричной суммы двоичных чисел
let sumInSeq Sequence =
    Seq.fold (
        fun acc x -> acc + binToInt x
                ) 0 Sequence

// Функция рекурсивного создания последовательности
let rec createSequence oldSeq count =
    if count > 0 then

        printf "Введите элемент последовательности: "
        let element = string(Console.ReadLine())
        let ifbin = checkIfBin element
        if not ifbin then
            printfn "Введенная строка не является бинарной!"
            createSequence oldSeq count
        else
            let number = binToInt element
            if number >= 1 && number <= 9 then     
                let seqElement = Seq.singleton element
                let newSeq =  Seq.append oldSeq seqElement
                createSequence newSeq (count - 1)
            else
                printfn "Число вне заданного диапазона!"
                createSequence oldSeq count
    else
        oldSeq

// Проверка заданного количества элементов
let rec checkInput() = 
    printf "Введите количество элементов последовательности: "
    let number = int(Console.ReadLine())
    if number < 0 then
        printfn "Количество элементов должно быть > 0!"
        checkInput()
    else
        number

[<EntryPoint>]
let main args = 
    let number = checkInput()

    let sequence = createSequence Seq.empty number
    let result = sumInSeq sequence
    printfn "Сумма двоичных чисел в последовательности равна: %i" result

    System.Console.ReadKey() |> ignore
    0

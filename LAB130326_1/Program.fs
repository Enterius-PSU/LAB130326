// Кушев Александр БАС-2
// Лабораторная работа №3 (Задание №1)

open System

// Функция расчета произведения цифр в числе
let rec mulNumbers x =
    if x = 0 then
        1
    else
        (x % 10) * mulNumbers (x / 10)

// Функция рекурсивного создания последовательности (с конечным числом элементов)
let rec createSequence oldSeq count =
    if count > 0 then

        printf "Введите элемент последовательности: "
        let element = int(Console.ReadLine())
        let seqElement = Seq.singleton element
        let newSeq =  Seq.append oldSeq seqElement
        createSequence newSeq (count - 1)
    else
        oldSeq

// Вывод элементов последовательности
let printSeq Sequence =
    printf "Полученная последовательность: "
    Seq.iter (printf "%A ") Sequence
    printfn ""

// Функция проверки частного случая и преобразования числа
let transform x = 
    if x = 0 then 
        0 
    else 
        mulNumbers (abs x)

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
    let result = Seq.map(fun i -> transform i) sequence
    printSeq result

    System.Console.ReadKey() |> ignore
    0

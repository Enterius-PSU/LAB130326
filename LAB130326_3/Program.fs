// Кушев Александр БАС-2
// Лабораторная работа №3 (Задание №3)

open System
open System.IO

// Функция поиска первого вхождения файла
let search filename dir=
    let files = Directory.GetFiles(
        dir, 
        filename, 
        SearchOption.AllDirectories
    )

    if files.Length > 0 then
        printfn "Файл найден: %s" files.[0]
    else
        printfn "Файл не найден."

// Проверка введенного пользователем пути
let rec checkDirectory() =
    printf "Введите путь к каталогу: "
    let dir = string(Console.ReadLine())
    if not (Directory.Exists dir) then
        printfn "Неверный путь к каталогу!"
        checkDirectory()
    else
       dir

// Проверка введенного пользователем названия файла
let rec checkFileName() =
    printf "Введите название файла (вместе с расширением): "
    let filename = string(Console.ReadLine())
    if filename = "" then
        printfn "Название файла не введено!"
        checkFileName()
    else
        filename


[<EntryPoint>]
let main args = 
    let dir = checkDirectory()
    let filename = checkFileName()
    let result = search filename dir
    
    System.Console.ReadKey() |> ignore
    0

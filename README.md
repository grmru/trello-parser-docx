# trello-parser-docx
Формирование файла формата docx (MS Office 2007+) из JSON выгрузки сервиса Trello

## Особенности для Linux
Для пакета DotNetCore.NPOI необходимо наличие libgdiplus.
Для Ubuntu 16.04 and above необходимо выполнить следующее:

```
apt-get install libgdiplus libc6-dev
cd /usr/lib
ln -s libgdiplus.so gdiplus.dll
```
echo off

SET iteration=%1
SET samples=%2
SET seed=%3

echo %iteration%
echo %samples%
echo %seed%

cd "bin/debug" 

Trivia.exe %iteration% %samples% %seed%

cd ../..

PAUSE

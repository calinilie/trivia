echo off

SET iteration=%1
SET samples=%2
SET seed=%3

IF [%iteration%]==[] set iteration=1

cd "bin/debug" 

echo generating log output...

Trivia.exe %iteration% %samples% %seed%

cd ../..

echo comparing log output to golden master...

git diff --no-index GoldenMaster "Change%iteration%"

PAUSE

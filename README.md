# NIGHTMARE SLAYER
NIGHT SLAYER Adalah Game 2D Platformer dan hack and slash, dengan menghancur kan musuh untuk menyelesaikan rintangan.
# BASE CONSEPT
Game dimana player harus membunuh musuh dengan combo-combo yang ada.musuh menyerang sesuai fase gelombang player dapat dikendalikan dan harus mengumpulkan soul untuk melakukan skill untuk membunuh player.
# MECHANIC
## Controling Player
Kita sebagai player (Main Character) yang akan bertarung dalam mimpi buruk seseorang, melawan pikiran jahat yang menyerupai monster-monster kegelapan. Cara mengendalikan player dengan mainkan analog dan tombol untuk menyesuaikan aksi dan combo yang sangat menarik.
Player Mechanic yang akan di implementasi :
1. Mana Star
- Dapat didapatkan saat membunuh monster
- Mana star berfungsi untuk player mengeluarkan skillnya
- dengan menggunakan mana Star dapat mengeluarkan skill dan combo yang mempunyai damage besar ke lawan
2. Shield Star
- Shield Star berfungsi untuk Player menahan damage dengan Shield Star
- Dapat didapatkan saat memukul monster
- Dengan Shield Star dapat menahan damage monster ke player, saat aktif shield damage yang diterima adalah 0
3. Attack Combo dalam semua keadaan
- Basic Attack terdapat 3 / N attack yang beragam
- Special Skill akan memakan Mana Star 
- Flying Attack
- Dash Attack
- Fall Attack
4. Health Bar dan Armor
- Health Berupa Bar seperti biasa berupa darah player
- Armor ketika monster memukul akan mengurangi armor terlebih dahulu
5. Combo Calculation
- Ketika Player telah memukul monster sebanyak lebih dari 10 akan akan notif combo 
6. Animation :
- Idle
- Run
- Die
- Jump
- Attack 1-N
- Skill 1 / N
- Dash
- Win Condisition
7. Ongoing
## Monster ( ENEMY )
Monster beragam yang bergerak dalam kegelapan yang mengganggu setiap mimpi indah manusia
Spesifikasi Monster :
1. Memiliki Hp dan Armor
- Ketika armor habis, akan terkena effect hurt
- ketika hp abis akan destroy
2. Attack Monster
- Attack akan tertrigger ketika ada player yang memasuki areanya
- hanya 1 jenis Attack yang hanya diterapkan dari setiap monster
3. ONGOING
##BOSS
Boss sebagai lawan terakhir dari penyelesaian setiap lantai atau dungeon
Spesifikasi Boss :
1. Memiliki 2 Fase Mode
2. Memiliki Health dan Armor Beregenerasi
3. Attack damage yang besar
4. Jenis Attack yang beragam

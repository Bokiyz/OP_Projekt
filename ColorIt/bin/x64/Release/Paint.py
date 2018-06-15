import clr
import sys
pyt_path = r'C:\Program Files\IronPython 2.7\Lib'
sys.path.append(pyt_path)
import random
clr.AddReference("System.Windows.Forms")
from System.Windows.Forms import *

def RandomNumber():
    return random.randint(0,5)

def Load(frm):
    frm.potezi = 0
    frm.potezi21.Text = str(frm.potezi) + " / 21"
    frm.novaBoja = -1
    for x in range(0, 144):
        a = RandomNumber()
        frm.pictureBoxes[x].BackColor = frm.boje[a]
        frm.brojBoje[x] = a
        if x == 0:
            frm.trenutnaBoja = frm.brojBoje[x]
            if a == 0:
                frm.btnZuta.Enabled = False
            elif a == 1:
                frm.btnZelena.Enabled = False
            elif a == 2:
                frm.btnCrvena.Enabled = False
            elif a == 3:
                frm.btnPlava.Enabled = False
            elif a == 4:
                frm.btnSmeda.Enabled = False
            elif a == 5:
                frm.btnRuzicasta.Enabled = False


def LoadStaro(frm):
    frm.potezi = 0
    frm.potezi21.Text = str(frm.potezi) + " / 21"
    frm.novaBoja = -1
    for x in range(0, 144):
        frm.pictureBoxes[x].BackColor = frm.boje[frm.brojBoje[x]]
        if x == 0:
            frm.trenutnaBoja = frm.brojBoje[x]
            if frm.trenutnaBoja == 0:
                frm.btnZuta.Enabled = False
            elif frm.trenutnaBoja == 1:
                frm.btnZelena.Enabled = False
            elif frm.trenutnaBoja == 2:
                frm.btnCrvena.Enabled = False
            elif frm.trenutnaBoja == 3:
                frm.btnPlava.Enabled = False
            elif frm.trenutnaBoja == 4:
                frm.btnSmeda.Enabled = False
            elif frm.trenutnaBoja == 5:
                frm.btnRuzicasta.Enabled = False


def Paintuj(frm, xKoor, yKoor, sBoja, nBoja):
    if xKoor > 0 and yKoor > 0 and xKoor < 13 and yKoor < 13:
        if frm.pictureBoxes[((xKoor - 1) * 12) + yKoor - 1].BackColor != frm.boje[sBoja]:
            return
        if frm.pictureBoxes[((xKoor - 1) * 12) + yKoor - 1].BackColor == frm.boje[sBoja]:
            frm.pictureBoxes[((xKoor - 1) * 12) + yKoor - 1].BackColor = frm.boje[nBoja]
        Paintuj(frm, xKoor - 1, yKoor, sBoja, nBoja)
        Paintuj(frm, xKoor + 1, yKoor, sBoja, nBoja)
        Paintuj(frm, xKoor, yKoor - 1, sBoja, nBoja)
        Paintuj(frm, xKoor, yKoor + 1, sBoja, nBoja)


def winCondition(frm, boja):
    br = 0
    for x in range(0, 144):
        if frm.pictureBoxes[x].BackColor == frm.boje[boja]:
            br = br + 1
    if br == 144:
        return True
    else:
        return False

def ispisHighscore(frm, broj):
    if broj == 0:
        frm.lblIme1.Text = frm.name;
        frm.lblPot1.Text = frm.potezi;
    elif broj == 1:
        frm.lblIme2.Text = frm.name;
        frm.lblPot2.Text = frm.potezi;
    else:
        frm.lblIme3.Text = frm.name;
        frm.lblPot3.Text = frm.potezi;
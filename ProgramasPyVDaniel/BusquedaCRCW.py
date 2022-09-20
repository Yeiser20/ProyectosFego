# -*- coding: utf-8 -*-
"""
Created on Mon May 24 23:22:34 2021

@author: victor daniel archundia
"""

"BUSQUEDA DE CRCW"

import math
from threading import Thread

# DEFINICION DE HILOS 
def Hilo_1(win,i):
        win.append(0)

def Hilo_2(L,win,i,j):
    if L[i] > L[j]:
        win[i]=1
    else:
        win[j]=1

def Hilo_3(n,win,L):
    for i in range(n):
        if (win[i] == 0):
            indexMin = i
    print ('Paso 3: Indice minimo ', indexMin + 1)

    print ('--->PROCESADORES UTILIZADOS: ', L[indexMin]) 

# PROGRAMA CONTROL    
def main():
    print ("----BUSQUEDA PRAM CRCW---")
    L=[]
    win=[]
    n=int(input("INGRESE EL NUMERO DE DATOS:"))
    i=1
    for i in range (n):
        n1=int(input("INGRESE UN NUMERO:"))
        L.append(n1)

    n = len(L)

    print ('ORIGINAL ',L)

    #LLAMADA AL HILO 1
    print('')
    for i in range(n):
        h1=Thread(target=Hilo_1,args=(win,n))
        h1.start()
        h1.join()
    print ('Paso 1: ', win)

    #LLAMADA AL HILO 2
    print ('\nWIN: ')
    j=0
    while(j<n):
        i=0
        while(i<j):
            h2=Thread(target=Hilo_2,args=(L,win,i,j))
            h2.start()
            h2.join()
            i=i+1
        j=j+1
    print ('Paso 2: ', win)

    #LLAMADA AL HILO 3
    print('')
    h3=Thread(target=Hilo_3,args=(n,win,L))
    h3.start()
    h3.join()

main()
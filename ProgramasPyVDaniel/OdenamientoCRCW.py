# -*- coding: utf-8 -*-
"""
Created on Mon May 24 22:46:10 2021

@author:victor daniel archundia
"""
"ORDENAMIENTO CRCW"
import os
import math
from threading import Thread

#DEFINICION DE HILOS 
def Hilo_1(win,i):
        win.append(0)

def Hilo_2(i,j,win,L):
    if L[i] > L[j]:
        win[i] = win[i] + 1
    else:
        win[j]=win[j] + 1

def Hilo_3(n,aux,L,win):
    for i in range(n):
        aux[win[i]] = L[i]
        
    print ('Paso 3: ', aux)

    for i in range(n):
        if (win[i] == 0):
            indexMin = i

    print ('\n--->PROCESADORES UTILIZADOS: ', L[indexMin] )

#PROGRAMA CONTROL
def main():
    print ("----ORDENAMIENTO PRAM CRCW---")
    L=[]
    win=[]
    aux=[]

    n=int( input("INGRESE EL NUMERO DE DATOS:"))
    
    i=1
    
    for i in range (n):
        
        n1=int(input("INGRESE UN NUMERO:"))
        
        L.append(n1)

    for i in range (n):
        aux.append(0)    

    n = len(L)

    print ('\nOriginal: ', L)

    print('')
    for i in range(n):
        h1=Thread(target=Hilo_1,args=(win,i))
        h1.start()
        h1.join()
    print ('Paso 1: ', win)

    print ('\nWIN')
    i=0
    while(i <= n):
        j=i+1
        while(j<n and i<j):
            h2=Thread(target=Hilo_2,args=(i,j,win,L))
            h2.start()
            h2.join()
            j=j+1
        i=i+1
    print ('Paso 2: ', win)

    print ('\nLISTA ORDENADA')
    h3=Thread(target=Hilo_3,args=(n,aux,L,win))
    h3.start()
    h3.join()

main()
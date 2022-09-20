# -*- coding: utf-8 -*-
"""
Created on Tue May 25 00:23:29 2021

@author:victor daniel archundia
"""

"BUSQUEDA EREW"

import os
import math
from threading import Thread


def hilo1(Temp2,i,j):
    Temp2.insert(j,Temp2[j-(2**i-1)])
 

def hilo2(K,Temp2,x,n):
    if(x<(n-1)):
        if(K[x]==Temp2[x]):
            Temp2[x]=x+1
        else:
            Temp2[x]=99999


def hilo3(Temp2,n,k):
    if(Temp2[(2**(k))-1]>Temp2[2**k]):
        Temp2[k]=Temp2[2*k]
    else:
        Temp2[k]=Temp2[(2**(k))-1]


def Broadcast(Temp,x,n):
    Temp2=[]
    Temp2=Temp
    Temp2.insert(0,numero)
    Temp2.insert(1,numero)
    i=1
    while(i<=lg):
        j=(2**(i-1))+1
        while(j<=2**i):
            t=Thread(target=hilo1,args=(Temp2,i,j))
            t.start()
            t.join()
            j=j+1
        i=i+1
     


def SearchPram(Temp,lista,n):
    i=0
    while(i<=n):
        t=Thread(target=hilo2,args=(lista,Temp,i,n))
        t.start()
        t.join()
        i=i+1


def MinPram(Temp,n):
    i=1
    while(i<=lg):
        j=1
        while(j<=int(n/(2**j))):
            t=Thread(target=hilo3,args=(Temp,n,i))
            t.start()
            t.join()
            j=j+1
        i=i+1




#Programa Principal
print ("BUSQUEDA PRAM EREW")
a=[]
Temp=[]
lista=[]
x=int(input("INGRESE EL NUMERO DE DATOS: "))
i=1
while (i<=x):
    n1=int(input("INGRESE DATO: "))
    lista.append(n1)
    print (lista)
    i+=1
n=len(lista)
lg=int(math.log(n,2))

numero=int(input("ingresa el valor a buscar: "))
print ("RESULTADOS OBTENIDOS")
print ("NUMEROS INGRESADOS: ")

print (lista)
Broadcast(Temp,numero,n)
print ("\nVECTOR TEMPORAL: ")
print (Temp)
SearchPram(Temp,lista,n)

print ("\nINDICES:")
print (Temp)
MinPram(Temp,n)
h=1
while(h<len(Temp)):
    if(Temp[h]!=99999):
        pos=Temp[h]
        break
    h=h+1
print ("DONDE",numero," ESTA EN LA POSICION NUMERO: ",pos)

os.system('pause')
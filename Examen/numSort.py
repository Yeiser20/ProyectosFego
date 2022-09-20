# -*- coding: utf-8 -*-
"""
Created on Sun May 16 22:53:11 2021

@author: danie
"""
import os

try:
    os.environ["OMP_NUM_THREADS"] = "1"
    os.environ["NUMEXPR_NUM_THREADS"] = "1"
    os.environ["MKL_NUM_THREADS"] = "1"
    import numSort as np
finally:
    del os.environ["OMP_NUM_THREADS"]
    del os.environ["NUMEXPR_NUM_THREADS"]
    del os.environ["MKL_NUM_THREADS"]

import utils

print(np.sort(np.load(utils.get_nummeros_file())))


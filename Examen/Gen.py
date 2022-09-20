# -*- coding: utf-8 -*-
"""
Created on Sun May 16 22:51:49 2021

@author: danie
"""

import numSort as np
import sys, utils

size = int(sys.argv[1]) if len(sys.argv) > 1 else 128
random_range = np.arange(size)
np.random.shuffle(random_range)
np.save(utils.get_numbers_file(), random_range)


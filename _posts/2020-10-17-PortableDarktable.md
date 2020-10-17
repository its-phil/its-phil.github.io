---
layout: post
title:  "Moving darktable around"
date:   2020-10-17 17:17:14 +0200
categories: jekyll update
---
I use darktable to process and export my raw photos. Having to switch machines from time to time it's important to take my settings and presets with me.

## Darktable config folder

On Linux, the configuration files are in `~/.config/darktable/`.

## Running darktable with a custom catalog

To run darktable with a custom dialog call it with the following arguments:
```
darktable --library /home/phil/Data/Pictures/Darktable/Darktable.db
```
This can be used to create an application launcher in Ubuntu.
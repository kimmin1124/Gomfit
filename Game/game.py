import pygame
import random
import datetime

pygame.init()
dWidth, dHeight = 500, 900

## 윈도우 서피스 셋업 ##
ourScreen = pygame.display.set_mode((dWidth, dHeight))
pygame.display.set_caption("Game")

## image Load ##
def load_image(str):
    return pygame.image.load("Images/" + str + ".png")
im_title = load_image("title")

clock = pygame.time.Clock()

WHITE = (255, 255, 255)
GREEN = (0, 255, 0)
BLUE = (0, 0, 128)
BLACK = (0, 0, 0)

GS_run = True;
title = "Title"
stage = "Stage"
cur_scene = title;

while GS_run:
    nextStage = False
    
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
        if event.type == pygame.KEYDOWN and event.key == pygame.K_SPACE:
            nextStage = True
            
    if nextStage and cur_scene is title:
        cur_scene = stage
        
    if cur_scene is title:
        ourScreen.fill((255,255,255))
        ourScreen.blit(im_title, (-350 , -100))
        pygame.display.flip()
    if cur_scene is stage:
        ourScreen.fill(BLUE)
        pygame.display.flip()
pygame.quit()
import pygame
import random
import datetime
import time
import os.path

WHITE = (255, 255, 255)
GREEN = (0, 255, 0)
BLUE = (0, 0, 128)
BLACK = (0, 0, 0)

## Class ##
class GameManager():
    def __init__(self, devMode = False):
        self.devMode = devMode
        self.tutorial = True
        self.window_size = (500, 900)
        self.display = pygame.display.set_mode(self.window_size)
        self.title = "Game"
        self.clock = pygame.time.Clock()
        self.game_is_running = False
        self.fontObj = pygame.font.Font("Fonts/나눔스퀘어B.ttf", 32)
        self.textSurfaceObj = fontObj.render("Hello World!", True, BLACK)
        self.textRectObj = textSurfaceObj.get_rect()
        self.textRectObj.center = (630, 32)
    
    def start_game(self):
        pygame.init()
        pygame.display.set_caption(self.title)
        self.gameState = "Title"
        
    def draw_background(self, image):
        self.display.fill((255,255,255))
        self.display.blit(image, (-350, -100))
        

## Utility ##
def load_image(str):
    path = os.path.sep.join(["Images", str + ".png"])
    return pygame.image.load(path)

def ui(gm):
    

if __name__ == "__main__":
    print("Game Start")
    gm = GameManager()
    gm.start_game()
    im_title = load_image("title")
    im_ingame = load_image("background")
    print("Loof Coming")
    while True:
        time.sleep(2.0)
        
        if gm.gameState == "Title":
            print("in the Title")
            ## Display Setting ##
            gm.draw_background(im_title)
            pygame.display.flip()
            
            ## Key Processing ##
            for event in pygame.event.get():
                if event.type == pygame.QUIT:
                    pygame.quit()
                if event.type == pygame.KEYDOWN:
                    if event.key == pygame.K_SPACE:
                        gm.gameState = "InGame"
                        
        if gm.gameState == 'InGame':
            ## Display Setting ##
            gm.draw_background(im_ingame)
            
            ## 플레이 시간 출력
            ## 일시정지 버튼 출력
            ## 하트 출력
            ## 화살표 출력
            ## 카메라 출력
            
            pygame.display.flip()
            
            if gm.game_is_running:
                whole_time = datetime.datetime.now()
                
            else:
                record = datetime.datetime.now()
            
            ## Key Processing ##
            for event in pygame.event.get():
                if event.type == pygame.QUIT:
                    pygame.quit()
                if event.type == pygame.KEYDOWN:
                    if event.key == pygame.K_SPACE:
                        print("다음 스테이지로")
            

